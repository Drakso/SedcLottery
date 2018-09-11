namespace Lottery.View.Model
{
    // These models are view models, meaning that are only used in the application
    // Users interaction reflect on these models. After that these models are mapped and transformed in to the original data models
    // In these models we put only the data and information that we need and use in the application. Everything else is left out
    public class AwardModel
    {
        public string AwardName { get; set; }
        public string AwardDescription { get; set; }
    }
}
