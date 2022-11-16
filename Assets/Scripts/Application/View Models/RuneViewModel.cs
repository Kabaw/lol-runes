using LoLRunes.Shared.Enums;

namespace LoLRunes.View.ViewModel
{
    public class RuneViewModel
    {
        public RuneTypeEnum RuneType { get; set; }

        public RuneViewModel DeepCopy()
        {
            return MemberwiseClone() as RuneViewModel;
        }
    }
}