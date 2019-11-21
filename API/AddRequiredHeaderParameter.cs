using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using System;

namespace API
{
    public class AddRequiredHeaderParameter : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.OperationDescription.Operation.Parameters.Add(
            new NSwag.OpenApiParameter
            {
                Name = "x-request-id",
                Kind = NSwag.OpenApiParameterKind.Header,
                Type = NJsonSchema.JsonObjectType.String,
                IsRequired = false,
                Description = "Request id. request with duplicate x-request-id will be ignored.",
                Style = NSwag.OpenApiParameterStyle.Simple
            });

            return true;
        }
    }
}
