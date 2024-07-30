using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities
{
    public class Banner:BaseEntity
    {
        public string ImageName { get;private set; }
        public string Link { get; private set; }
        public BannerPossition Possition { get; private set; }

        public Banner(string imageName, string link, BannerPossition possition)
        {
            Guard(imageName, link);
            ImageName = imageName;
            Link = link;
            Possition = possition;
        }

        public void Edit(string imageName, string link, BannerPossition possition)
        {
            Guard(imageName, link);
            ImageName = imageName;
            Link = link;
            Possition = possition;
        }

        public void Guard(string imageName, string link)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        }
    }

    public enum BannerPossition
    {
        LeftSlider_Top,
        LeftSlider_Bottom,
        BottomNavbar
    }
}
