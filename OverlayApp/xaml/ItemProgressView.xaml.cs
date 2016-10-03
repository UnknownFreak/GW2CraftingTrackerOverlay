using GW2APIComponent.GW2Components.Strings;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace OverlayApp
{
    /// <summary>
    /// Interaction logic for ItemProgressView.xaml
    /// </summary>
    [Serializable]
    public partial class ItemProgressView : UserControl
    {
        short i=0;
        System.Timers.Timer t = new System.Timers.Timer(5000);
        System.Timers.Timer costTimer = new System.Timers.Timer(15000);
        ItemRecipe ir;

        /// <summary>
        /// Default ctor.
        /// </summary>
        public ItemProgressView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes a progress view.
        /// </summary>
        /// <param name="_ir">The item recipe to have the progress view to track.</param>
        public ItemProgressView(ItemRecipe _ir)
        {
            ir = _ir;
            try
            {
            InitializeComponent();
            }
            catch (System.Windows.Markup.XamlParseException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            update();
            t.Elapsed += t_Elapsed;
            t.AutoReset = true;
            t.Start();
            if(ir.aquireIcons.Count == 1)
            {
                t.Stop();
                CraftingIcons.Source = getNextCraftingIcon();
            }

            costTimer.Elapsed += cost_Elapsed;
            costTimer.AutoReset = true;
            costTimer.Start();
            EstimatedCost.Content = "";
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                TimeSpan ts = new TimeSpan(0,0,1);
                CraftingIcons.ChangeSource(getNextCraftingIcon(),ts,ts);
            }));
        }

        void cost_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                //TimeSpan ts = new TimeSpan(0, 0, 5);

                string lable = "";

                if (ir.priceList == CostToList.COST_BUY_NOW)
                {
                    ir.priceList = CostToList.COST_BUY_NOW_STACK;
                    lable = "Est Buy Cost: " + longToGold(ir.tpCost.costBuyNow) + " ea";
                }
                else if (ir.priceList == CostToList.COST_BUY_NOW_STACK)
                {
                    ir.priceList = CostToList.COST_BUY_ORDER;
                    lable = "Est Buy Cost: " + longToGold(ir.tpCost.costBuyNowStack) + " stack";
                }
                else if (ir.priceList == CostToList.COST_BUY_ORDER)
                {
                    ir.priceList = CostToList.COST_BUY_ORDER_STACK;
                    lable = "Est Order Cost: " + longToGold(ir.tpCost.costPlaceOrder) + " ea";
                }
                else if (ir.priceList == CostToList.COST_BUY_ORDER_STACK)
                {
                    ir.priceList = CostToList.COST_BUY_NOW;
                    lable = "Est Order Cost: " + longToGold(ir.tpCost.costPlaceOrderStack) + " stack";
                }

                if (ir.hideCost)
                {
                    EstimatedCost.Content = "";
                }
                else
                {
                    EstimatedCost.Content = lable;
                }

            }));
        }

        /// <summary>
        /// Updates the view with new information.
        /// </summary>
        public void update()
        {

            ItemName.Content = ir.name;
            if(Image.Source == null)
                try
                {
                    Image.Source = new BitmapImage(new Uri(ir.itemIcon));
                }
                catch
                { }
            Progress.Value = ir.current;
            Progress.Maximum = ir.totalCount;
            ProgressLabel.Content = ir.current + "/" + ir.totalCount;
        }

        private string longToGold(long _gold)
        {
            long gold = _gold / 10000;
            long silver = (_gold / 100) - gold * 100;
            long copper = (_gold) - (silver * 100) - (gold * 10000);
            string text = gold.ToString() + "g " + silver.ToString() + "s " + copper.ToString() + "c";
            return text;
        }


        /// <summary>
        /// Updates the view with new information.
        /// </summary>
        /// <param name="obj">The object to use to fetch new information.</param>
        public void update(GW2APIComponent.GW2Object obj)
        {
            ir.updateItemCount(obj);
            update();
        }
        /// <summary>
        /// Gets the next icon for the crafting professions.
        /// </summary>
        /// <returns></returns>
        public BitmapImage getNextCraftingIcon()
        {
            i++;
            if (ir.aquireIcons.Count == 0)
                return new BitmapImage();
            else if (i >= ir.aquireIcons.Count)
                i = 0;
            return new BitmapImage(new Uri(IconStrings.crafting[ir.aquireIcons[i]]));
        }

        private void userControl_Unloaded(object sender, RoutedEventArgs e)
        {
            t.Stop();
            t.Dispose();
            costTimer.Stop();
            costTimer.Dispose();
        }
    }
}
