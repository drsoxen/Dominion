using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;

namespace ZDominionSilverlight
{
    public partial class MainPage : UserControl
    {
        bool m_Dominion;
        bool m_Intrigue;
        bool m_Alchemy;
        bool m_Hinterlands;
        bool m_Cornucopia;
        bool m_PromoCards;
        bool m_Seaside;
        bool m_Prosperity;

        Dictionary<string, List<string>> Cards;

        int index;

        ImageSourceConverter converter;

        public MainPage()
        {
            InitializeComponent();

            button_Alchemy.Background = new SolidColorBrush(Colors.Green);
            button_Cornucopia.Background = new SolidColorBrush(Colors.Green);
            button_Dominion.Background = new SolidColorBrush(Colors.Green);
            button_Hinterlands.Background = new SolidColorBrush(Colors.Green);
            button_Intrigue.Background = new SolidColorBrush(Colors.Green);
            button_PromoCards.Background = new SolidColorBrush(Colors.Green);
            button_Prosperity.Background = new SolidColorBrush(Colors.Green);
            button_Seaside.Background = new SolidColorBrush(Colors.Green);

            m_Dominion = true;
            m_Intrigue = true;
            m_Alchemy = true;
            m_Hinterlands = true;
            m_Cornucopia = true;
            m_PromoCards = true;
            m_Seaside = true;
            m_Prosperity = true;

            converter = new ImageSourceConverter();

            Cards = new Dictionary<string, List<string>>();

            index = 0;

            LoadCards();

            //for (int i = 0; i < Cards.Count; i++)
            //    for (int j = 0; j < Cards.ElementAt(i).Value.Count; j++)
            //        converter.ConvertFromString("Cards/" + Cards.ElementAt(i).Value[j] + ".jpg");

        }
        #region Load Cards
        void LoadCards()
        {
            List<string> tempList = new List<string>();
            tempList.Add("Adventurer");
            tempList.Add("Bureaucrat");
            tempList.Add("Cellar");
            tempList.Add("Chancellor");
            tempList.Add("Chapel");
            tempList.Add("Council Room");
            tempList.Add("Feast");
            tempList.Add("Festival");
            tempList.Add("Gardens");
            tempList.Add("Laboratory");
            tempList.Add("Library");
            tempList.Add("Market");
            tempList.Add("Militia");
            tempList.Add("Mine");
            tempList.Add("Moat");
            tempList.Add("Moneylender");
            tempList.Add("Remodel");
            tempList.Add("Smithy");
            tempList.Add("Spy");
            tempList.Add("Thief");
            tempList.Add("Throne Room");
            tempList.Add("Village");
            tempList.Add("Witch");
            tempList.Add("Woodcutter");
            tempList.Add("Workshop");

            Cards.Add("Dominion", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Baron");
            tempList.Add("Bridge");
            tempList.Add("Conspirator");
            tempList.Add("Coppersmith");
            tempList.Add("Courtyard");
            tempList.Add("Duke");
            tempList.Add("Great Hall");
            tempList.Add("Harem");
            tempList.Add("Ironworks");
            tempList.Add("Masquerade");
            tempList.Add("Mining Village");
            tempList.Add("Minion");
            tempList.Add("Nobles");
            tempList.Add("Pawn");
            tempList.Add("Saboteur");
            tempList.Add("Scout");
            tempList.Add("Secret Chamber");
            tempList.Add("Shanty Town");
            tempList.Add("Steward");
            tempList.Add("Swindler");
            tempList.Add("Torturer");
            tempList.Add("Trading Post");
            tempList.Add("Tribute");
            tempList.Add("Upgrade");
            tempList.Add("Wishing Well");

            Cards.Add("Intrigue", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Ambassador");
            tempList.Add("Bazaar");
            tempList.Add("Caravan");
            tempList.Add("Cutpurse");
            tempList.Add("Embargo");
            tempList.Add("Explorer");
            tempList.Add("Fishing Village");
            tempList.Add("Ghost Ship");
            tempList.Add("Haven");
            tempList.Add("Island");
            tempList.Add("Lighthouse");
            tempList.Add("Lookout");
            tempList.Add("Merchant Ship");
            tempList.Add("Native Village");
            tempList.Add("Navigator");
            tempList.Add("Outpost");
            tempList.Add("Pearl Diver");
            tempList.Add("Pirate Ship");
            tempList.Add("Salvager");
            tempList.Add("Sea Hag");
            tempList.Add("Smugglers");
            tempList.Add("Tactician");
            tempList.Add("Treasure Map");
            tempList.Add("Treasury");
            tempList.Add("Warehouse");
            tempList.Add("Wharf");

            Cards.Add("Seaside", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Alchemist");
            tempList.Add("Apothecary");
            tempList.Add("Apprentice");
            tempList.Add("Familiar");
            tempList.Add("Golem");
            tempList.Add("Herbalist");
            tempList.Add("Philosophers Stone");
            tempList.Add("Possession");
            tempList.Add("Scrying Pool");
            tempList.Add("Transmute");
            tempList.Add("University");
            tempList.Add("Vineyard");

            Cards.Add("Alchemy", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Bank");
            tempList.Add("Bishop");
            tempList.Add("City");
            tempList.Add("Contraband");
            tempList.Add("Counting House");
            tempList.Add("Expand");
            tempList.Add("Forge");
            tempList.Add("Goons");
            tempList.Add("Grand Market");
            tempList.Add("Hoard");
            tempList.Add("Kings Court");
            tempList.Add("Loan");
            tempList.Add("Mint");
            tempList.Add("Monument");
            tempList.Add("Mountebank");
            tempList.Add("Peddler");
            tempList.Add("Quarry");
            tempList.Add("Rabble");
            tempList.Add("Royal Seal");
            tempList.Add("Talisman");
            tempList.Add("Trade Route");
            tempList.Add("Vault");
            tempList.Add("Venture");
            tempList.Add("Watchtower");
            tempList.Add("Workers Village");


            Cards.Add("Prosperity", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Fairgrounds");
            tempList.Add("Farming Village");
            tempList.Add("Fortune Teller");
            tempList.Add("Hamlet");
            tempList.Add("Harvest");
            tempList.Add("Horn of Plenty");
            tempList.Add("Horse Traders");
            tempList.Add("Hunting Party");
            tempList.Add("Jester");
            tempList.Add("Menagerie");
            tempList.Add("Remake");
            tempList.Add("Tournament");
            tempList.Add("Young Witch");

            Cards.Add("Cornucopia", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Border Village");
            tempList.Add("Cache");
            tempList.Add("Cartographer");
            tempList.Add("Crossroads");
            tempList.Add("Develop");
            tempList.Add("Duchess");
            tempList.Add("Embassy");
            tempList.Add("Farmland");
            tempList.Add("Fools Gold");
            tempList.Add("Haggler");
            tempList.Add("Highway");
            tempList.Add("IllGotten Gains");
            tempList.Add("Inn");
            tempList.Add("Jack of all Trades");
            tempList.Add("Mandarin");
            tempList.Add("Margrave");
            tempList.Add("Noble Brigand");
            tempList.Add("Nomad Camp");
            tempList.Add("Oasis");
            tempList.Add("Oracle");
            tempList.Add("Scheme");
            tempList.Add("Silk Road");
            tempList.Add("Spice Merchant");
            tempList.Add("Stables");
            tempList.Add("Trader");
            tempList.Add("Tunnel");


            Cards.Add("Hinterlands", new List<string>(tempList));
            tempList.Clear();

            tempList.Add("Black Market");
            tempList.Add("Envoy");
            tempList.Add("Governor");
            tempList.Add("Stash");
            tempList.Add("Walled Village");

            Cards.Add("PromoCards", new List<string>(tempList));
            tempList.Clear();
        }
        #endregion

        #region top Buttons
        private void button_Dominion_Click(object sender, RoutedEventArgs e)
        {
            m_Dominion = !m_Dominion;
            button_Dominion.Background = m_Dominion ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_Intrigue_Click(object sender, RoutedEventArgs e)
        {
            m_Intrigue = !m_Intrigue;
            button_Intrigue.Background = m_Intrigue ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_Seaside_Click(object sender, RoutedEventArgs e)
        {
            m_Seaside = !m_Seaside;
            button_Seaside.Background = m_Seaside ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_Alchemy_Click(object sender, RoutedEventArgs e)
        {
            m_Alchemy = !m_Alchemy;
            button_Alchemy.Background = m_Alchemy ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_Prosperity_Click(object sender, RoutedEventArgs e)
        {
            m_Prosperity = !m_Prosperity;
            button_Prosperity.Background = m_Prosperity ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_Cornucopia_Click(object sender, RoutedEventArgs e)
        {
            m_Cornucopia = !m_Cornucopia;
            button_Cornucopia.Background = m_Cornucopia ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_Hinterlands_Click(object sender, RoutedEventArgs e)
        {
            m_Hinterlands = !m_Hinterlands;
            button_Hinterlands.Background = m_Hinterlands ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        private void button_PromoCards_Click(object sender, RoutedEventArgs e)
        {
            m_PromoCards = !m_PromoCards;
            button_PromoCards.Background = m_PromoCards ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }
        #endregion

        #region go Button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<string> toPopulate = new List<string>();

            if (m_Dominion)
            {
                for (int i = 0; i < Cards["Dominion"].Count; i++)
                    toPopulate.Add(Cards["Dominion"][i]);
            }
            if (m_Intrigue)
            {
                for (int i = 0; i < Cards["Intrigue"].Count; i++)
                    toPopulate.Add(Cards["Intrigue"][i]);
            }
            if (m_Alchemy)
            {
                for (int i = 0; i < Cards["Alchemy"].Count; i++)
                    toPopulate.Add(Cards["Alchemy"][i]);
            }
            if (m_Seaside)
            {
                for (int i = 0; i < Cards["Seaside"].Count; i++)
                    toPopulate.Add(Cards["Seaside"][i]);
            }
            if (m_Prosperity)
            {
                for (int i = 0; i < Cards["Prosperity"].Count; i++)
                    toPopulate.Add(Cards["Prosperity"][i]);
            }
            if (m_Cornucopia)
            {
                for (int i = 0; i < Cards["Cornucopia"].Count; i++)
                    toPopulate.Add(Cards["Cornucopia"][i]);
            }
            if (m_Hinterlands)
            {
                for (int i = 0; i < Cards["Hinterlands"].Count; i++)
                    toPopulate.Add(Cards["Hinterlands"][i]);
            }
            if (m_PromoCards && (m_Alchemy ||m_Cornucopia ||m_Dominion ||m_Hinterlands ||m_Intrigue ||m_Prosperity ||m_Seaside))
            {
                for (int i = 0; i < Cards["PromoCards"].Count; i++)
                    toPopulate.Add(Cards["PromoCards"][i]);
            }


            Random rand = new Random();
            List<int> usedIndexes = new List<int>();
            List<string> FinalList = new List<string>();
            int temp;

            for (int i = 0; i < 10; i++)
            {
                do
                {
                    temp = rand.Next(0, toPopulate.Count);
                } while (usedIndexes.Contains(temp));
                usedIndexes.Add(temp);

                FinalList.Add(toPopulate[temp]);
            }

                pictureBox1.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[0] + ".jpg");
                pictureBox2.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[1] + ".jpg");
                pictureBox3.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[2] + ".jpg");
                pictureBox4.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[3] + ".jpg");
                pictureBox5.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[4] + ".jpg");
                pictureBox6.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[5] + ".jpg");
                pictureBox7.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[6] + ".jpg");
                pictureBox8.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[7] + ".jpg");
                pictureBox9.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[8] + ".jpg");
                pictureBox10.Source = (ImageSource)converter.ConvertFromString("Cards/" + FinalList[9] + ".jpg");
        }
        #endregion
    }
}
