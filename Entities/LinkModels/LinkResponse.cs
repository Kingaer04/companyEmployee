using Entities.Models;

namespace Entities.LinkModels
{
    public class LinkResponse
    {
        public bool HasLinks { get; set; }
        public List<ShapedEntity> ShapedEntities { get; set; }
        public LinkCollectionWrapper<ShapedEntity> LinkedEntities { get; set; }

        public LinkResponse() {
            LinkedEntities = new LinkCollectionWrapper<ShapedEntity>();
            ShapedEntities = new List<ShapedEntity>();
        }
    }
}
