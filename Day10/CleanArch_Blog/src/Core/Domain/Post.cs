using Domain.Common;

namespace Domain;
public class Post : BaseDomainEntity
{
    public string  Title { get; set; } = "";
    public string Content { get; set; } = "";


}

