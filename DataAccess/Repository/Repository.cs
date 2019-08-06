using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System;

namespace DataAccess.Repository
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : class
    {
        public Repository(DbSet<T> dbSet) : base(dbSet)
        {
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        protected NpgsqlParameter InParam(string name, int? value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.Integer)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InParam(string name, short? value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.Smallint)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InParam(string name, long? value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.Bigint)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InParam(string name, decimal? value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.Numeric)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InParam(string name, DateTime? value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.TimestampTz)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InParam(string name, string value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.Varchar)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InParam(string name, bool? value)
        {
            var val = value != null ? (object)value : DBNull.Value;
            return new NpgsqlParameter(name, NpgsqlDbType.Boolean)
            {
                Direction = System.Data.ParameterDirection.Input,
                Value = val,
                NpgsqlValue = val
            };
        }

        protected NpgsqlParameter InOutParamInt(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.Integer)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }

        protected NpgsqlParameter InOutParamShort(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.Smallint)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }

        protected NpgsqlParameter InOutParamLong(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.Bigint)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }

        protected NpgsqlParameter InOutParamDecimal(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.Numeric)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }

        protected NpgsqlParameter InOutParamDateTime(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.TimestampTz)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }

        protected NpgsqlParameter InOutParamString(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.Varchar)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }

        protected NpgsqlParameter OutParamBoolean(string name)
        {
            return new NpgsqlParameter(name, NpgsqlDbType.Boolean)
            {
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
        }
    }
}
