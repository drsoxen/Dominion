using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace DominionCards
{
    class DominionSet
    {
        public string Name;
        //public string ImgSrc; // Not yet available
        public List<DominionCard> Cards = new List<DominionCard>();
    }

    [Flags]
    enum DominionCardType
    {
        Unknown,
        Action,
        Treasure,
        Attack
    }

    class DominionCard
    {
        public string Name;
        public DominionSet Set;
        public DominionCardType CardType = DominionCardType.Unknown;
        public string ImgSrc;
    }

    class DiehrstraitsScrape
    {
        private const string titletag = "title=\'";
        private const string cardimgtag = "class='card_img'";
        private const string imgtag = "src=\'";

        private static void PopulateCard(DominionCard card)
        {
            HttpWebRequest req = HttpWebRequest.Create("http://dominion.diehrstraits.com/?card=" + card.Name) as HttpWebRequest;
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(rep.GetResponseStream());
            string site = reader.ReadToEnd();
            string siteparse = site;

            // Find the card image
            if (siteparse.Contains(cardimgtag))
            {
                // Then look for the image source. Otherwise it would just grab the first images source from the page.
                string leftovers = siteparse.Substring(siteparse.IndexOf(cardimgtag));
                if (leftovers.Contains(imgtag))
                {
                    card.ImgSrc = leftovers.Substring(leftovers.IndexOf(imgtag) + imgtag.Length, leftovers.IndexOf("'"));
                }

            }

        }

        public static List<DominionSet> Scrape()
        {
            List<DominionSet> sets = new List<DominionSet>();

            sets.Add(GetSet("Base"));

            return sets;
        }

        public static DominionSet GetSet(string setname)
        {
            DominionSet set = new DominionSet();
            set.Name = setname;
            List<DominionCard> cards = new List<DominionCard>();
            HttpWebRequest req = HttpWebRequest.Create("http://dominion.diehrstraits.com/?set=" + setname) as HttpWebRequest;
            HttpWebResponse rep = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(rep.GetResponseStream());
            string site = reader.ReadToEnd();
            string siteparse = site;
            // Get names
            while (siteparse.Contains(titletag))
            {
                string leftovers = siteparse.Substring(siteparse.IndexOf(titletag) + titletag.Length);
                string cardname = leftovers.Substring(0, leftovers.IndexOf("\'"));
                DominionCard card = new DominionCard();
                card.Name = cardname;
                cards.Add(card);
                card.Set = set;
                set.Cards.Add(card);
                PopulateCard(card);
                siteparse = leftovers;
            }

            return set;
        }
    }
}
