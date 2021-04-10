using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Concrete
{
   public class Brand:IEntity, Core.Entities.IEntity
   {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
