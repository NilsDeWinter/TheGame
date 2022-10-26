using System;
using System.Collections.Generic;
using System.Text;

namespace TheGame.Core
{
    public class Card
    {
        public string Id { get; set; }
        public string PictureFilepathBack { get; set; }
        public string PictureFilepathFront { get; set; }
        /// <summary>
        /// Can be the base game or an extension
        /// </summary>
        public string Origin { get; set; }

        public Card(string id, string pictureFilepathBack, string pictureFilepathFront, string origin)
        {
            Id = id;
            PictureFilepathBack = pictureFilepathBack;
            PictureFilepathFront = pictureFilepathFront;
            Origin = origin;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(PictureFilepathBack)}: {PictureFilepathBack}, {nameof(PictureFilepathFront)}: {PictureFilepathFront}, {nameof(Origin)}: {Origin}";
        }
    }
}
