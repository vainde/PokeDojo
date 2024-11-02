namespace PokeDojo.src.Value
{
    public class StatValue
    {
        EffortValue effortValue;
        IndividualValue individualValue;

        public StatValue()
        {
            effortValue = new EffortValue();
            individualValue = new IndividualValue();
        }

        public EffortValue GetEffortValue()
        {
            return effortValue;
        }

        public IndividualValue GetIndividualValue()
        {
            return individualValue;
        }
    }
}
