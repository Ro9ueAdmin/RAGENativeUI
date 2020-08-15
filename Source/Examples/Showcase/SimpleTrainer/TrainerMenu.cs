namespace RNUIExamples.Showcase.SimpleTrainer
{
    using RAGENativeUI;
    using RAGENativeUI.Elements;

    internal sealed class TrainerMenu : UIMenu
    {
        public const string Title = "TRAINER";
        public static string SubMenuTitle(string title) => $"{Title}: {title}";

        public TrainerMenu() : base("", Title)
        {
            Plugin.Pool.Add(this);

            {
                UIMenuItem item = new UIMenuItem("Spawn Vehicle");

                AddItem(item);
                BindMenuToItem(new SpawnVehicleMenu(), item);
            }

            {
                UIMenuItem item = new UIMenuItem("Vehicle Options");

                AddItem(item);
                BindMenuToItem(new VehicleOptionsMenu(), item);
            }

            CustomizeMenu(this);
        }

        public static void CustomizeMenu(UIMenu menu)
        {
            menu.Width += 0.04f;
            menu.RemoveBanner();
            foreach (var subMenu in menu.Children.Values)
            {
                CustomizeMenu(subMenu);
            }
        }
    }
}
