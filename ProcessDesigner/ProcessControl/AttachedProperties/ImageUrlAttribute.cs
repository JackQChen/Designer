using System;

namespace ProcessControl
{
    public class ImageUrlAttribute : Attribute
    {
        private string imageUrl;
        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
        }

        public ImageUrlAttribute(string imageUrl)
        {
            this.imageUrl = imageUrl;
        }
    }
}
