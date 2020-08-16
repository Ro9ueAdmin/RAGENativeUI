namespace RNUIExamples.Showcase.SimpleTrainer
{
    using RAGENativeUI;
    using RAGENativeUI.Elements;

    internal sealed class TrainerMenu : TrainerMenuBase
    {
        public TrainerMenu() : base(TopTitle)
        {
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
        }
    }

    internal abstract class TrainerMenuBase : UIMenu
    {
        public const string TopTitle = "TRAINER";
        public static string SubMenuTitle(string title) => $"{TopTitle}: {title}";

        public TrainerMenuBase(string title) : base("", title)
        {
            Plugin.Pool.Add(this);

            Width += 0.04f;
            RemoveBanner();
        }
    }
}
