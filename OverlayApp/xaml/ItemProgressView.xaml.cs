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
        }

        void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                TimeSpan ts = new TimeSpan(0,0,1);
                CraftingIcons.ChangeSource(getNextCraftingIcon(),ts,ts);
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
        }
    }
}
