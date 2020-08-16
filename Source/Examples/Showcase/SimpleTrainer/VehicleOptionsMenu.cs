namespace RNUIExamples.Showcase.SimpleTrainer
{
    using Rage;

    using RAGENativeUI;
    using RAGENativeUI.Elements;

    internal sealed class VehicleOptionsMenu : TrainerMenuBase
    {
        private Vehicle currentVehicle;

        private Vehicle CurrentVehicle
        {
            get => currentVehicle;
            set
            {
                currentVehicle = value;

                bool exists = value;
                foreach (var i in MenuItems)
                {
                    i.Enabled = exists;
                }
            }
        }

        public VehicleOptionsMenu() : base(SubMenuTitle("VEHICLE OPTIONS"))
        {
            var repair = new UIMenuItem("Repair");
            repair.Activated += (s, i) => { if (CurrentVehicle) CurrentVehicle.Repair(); };

            AddItems(repair);

            CurrentVehicle = Game.LocalPlayer.Character.CurrentVehicle;
        }

        public override void ProcessControl()
        {
            var playerCurrVehicle = Game.LocalPlayer.Character.CurrentVehicle;

            if (CurrentVehicle != playerCurrVehicle)
            {
                CurrentVehicle = playerCurrVehicle;
            }

            base.ProcessControl();
        }
    }
}
