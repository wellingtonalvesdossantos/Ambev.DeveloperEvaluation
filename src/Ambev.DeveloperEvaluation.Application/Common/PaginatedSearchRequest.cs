using Ambev.DeveloperEvaluation.Domain.Common;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Common;

public class PaginatedSearchRequest : PaginatedSearchBase
{
    [JsonIgnore]
    public override int DefaultPageSize => 10;

    [JsonIgnore]
    public override int MaxPageSize => base.MaxPageSize;

    [JsonPropertyName("_size")]
    public override int? PageSize { get => base.PageSize; set => base.PageSize = value; }

    [JsonPropertyName("_page")]
    public override int? CurrentPage { get => base.CurrentPage; set => base.CurrentPage = value; }
}