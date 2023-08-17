using Domain.Common;

namespace Domain;
public class Comment : BaseDomainEntity
{
    public int PostId { get; set; }
    public string Content { get; set; } = "";


}