using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ticker
{
    class TickerProcessor
    {
        private readonly BlockingCollection<byte[]> _internalQueue;
        private readonly SortedDictionary<int, CandleStick> _candleSticks;
        private CancellationToken _cancellationToken;
        private CandleStick recentTick;
        private CandleStick firstTick;
        public TickerProcessor()
        {
            _candleSticks = new SortedDictionary<int, CandleStick>();
            _internalQueue = new BlockingCollection<byte[]>();
        }

        void Process(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

        }

        void QueueReader()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {

            }
            _internalQueue.CompleteAdding();
        }

        void QueueProcessor()
        {
            while (!_internalQueue.IsCompleted)
            {
                if (_internalQueue.TryTake(out byte[] message))
                {
                    if (message.Length == 5)//TODO add proper condition
                    {
                        var tradeTime = 0;
                        decimal price = 0;
                        decimal volume = 0;
                        if (recentTick == null || recentTick.Open != tradeTime)
                        {
                            if (!_candleSticks.TryGetValue(tradeTime, out recentTick))
                            {
                                recentTick = new CandleStick() { Start = tradeTime, Close = price, Count = 1, High = price, Low = price, Open = price, Volume = volume };
                                _candleSticks.Add(tradeTime, recentTick);
                            }
                        }
                        else
                        {
                            recentTick.Close = price;

                            if (price > recentTick.High)
                                recentTick.High = price;

                            if (price < recentTick.Low)
                                recentTick.Low = price;

                            recentTick.Count++;
                            recentTick.Volume += volume;
                        }
                    }
                    else if (message.Length == 3 && message[0] == 10)//TODO add proper condition
                    {
                        var nowSec = DateTime.UtcNow.AddDays(-1).Second;
                        var listToRemove = new List<int>();
                        foreach (var item in _candleSticks)
                        {
                            if (item.Key < nowSec)
                                listToRemove.Add(item.Key);
                            else
                                break;
                        }
                        for (int i = 0; i < listToRemove.Count; i++)
                            _candleSticks.Remove(listToRemove[i]);

                        var tick = new CandleStick() { };
                        bool isfirst = true;
                        foreach (var item in _candleSticks)
                        {
                            if (isfirst)
                            {
                                tick.Open = item.Value.Open;
                                isfirst = false;
                            }
                            if (tick.Low > item.Value.Low)
                                tick.Low = item.Value.Low;

                            if (tick.High < item.Value.High)
                                tick.High = item.Value.High;

                            tick.Close = item.Value.Close;
                            tick.Volume += item.Value.Volume;
                        }
                    }
                }
            }
        }
    }
}
