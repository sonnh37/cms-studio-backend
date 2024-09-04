namespace CMS.Studio.Domain.Configs.Mapping;

public partial class MappingProfile
{
    public MappingProfile()
    {
        UserMapping();
        ServiceMapping();
        PhotoMapping();
        OutfitMapping();
        AlbumMapping();
    }
}