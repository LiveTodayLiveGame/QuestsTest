namespace LiveToday
{
    public interface IQuest
    {
        int RequiredQuantity { get; }

        QuestsResources Item { get; }
    }
}
