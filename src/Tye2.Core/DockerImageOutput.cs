using System;

namespace Tye2.Core
{
    public class DockerImageOutput : ServiceOutput
    {
        public DockerImageOutput(string imageName, string imageTag)
        {
            if (imageName is null)
            {
                throw new ArgumentNullException(nameof(imageName));
            }

            if (imageTag is null)
            {
                throw new ArgumentNullException(nameof(imageTag));
            }

            ImageName = imageName;
            ImageTag = imageTag;
        }

        public string ImageName { get; }

        public string ImageTag { get; }
    }
}
