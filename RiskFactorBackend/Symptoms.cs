namespace RiskFactorBackend;

public enum SymptomPriority { HighPriority, MediumPriority, NonPriority, RiskFactor, NonFactor }

public record Symptom(
    string Name, // unique
    string Description = "",
    string[] DialogueOptions = null!
);

public record SymptomSelect(
    string Name,
    string Dialogue = ""
);

public class SymptomBank
{
    private readonly Random _random = new();
    private readonly Dictionary<SymptomPriority, List<Symptom>> _symptoms = new()
        {
            [SymptomPriority.HighPriority] = new()
            {
                new Symptom("HighTest1", "description", new [] { "HighTest1 option 1", "HighTest1 option 2" }),
                new Symptom("HighTest2", "description", new [] { "HighTest2 option 1", "HighTest2 option 2" }),
                new Symptom("HighTest3", "description", new [] { "HighTest3 option 1", "HighTest3 option 2" }),
            },
            [SymptomPriority.MediumPriority] = new()
            {
                new Symptom("MediumTest1", "description", new [] { "MediumTest1 option 1", "MediumTest1 option 2" }),
                new Symptom("MediumTest2", "description", new [] { "MediumTest2 option 1", "MediumTest2 option 2" }),
                new Symptom("MediumTest3", "description", new [] { "MediumTest3 option 1", "MediumTest3 option 2" }),
            },
            [SymptomPriority.NonPriority] = new()
            {
                new Symptom("NonPriorityTest1", "description", new [] { "NonPriorityTest1 option 1", "NonPriorityTest1 option 2" }),
                new Symptom("NonPriorityTest2", "description", new [] { "NonPriorityTest2 option 1", "NonPriorityTest2 option 2" }),
                new Symptom("NonPriorityTest3", "description", new [] { "NonPriorityTest3 option 1", "NonPriorityTest3 option 2" }),
            },
            [SymptomPriority.RiskFactor] = new()
            {
                new Symptom("RiskFactorTest1", "description", new [] { "RiskFactorTest1 option 1", "RiskFactorTest1 option 2" }),
                new Symptom("RiskFactorTest2", "description", new [] { "RiskFactorTest2 option 1", "RiskFactorTest2 option 2" }),
                new Symptom("RiskFactorTest3", "description", new [] { "RiskFactorTest3 option 1", "RiskFactorTest3 option 2" }),
            },
            [SymptomPriority.NonFactor] = new()
            {
                new Symptom("NonFactorTest1", "description", new [] { "NonFactorTest1 option 1", "NonFactorTest1 option 2" }),
                new Symptom("NonFactorTest2", "description", new [] { "NonFactorTest2 option 1", "NonFactorTest2 option 2" }),
                new Symptom("NonFactorTest3", "description", new [] { "NonFactorTest3 option 1", "NonFactorTest3 option 2" }),
            },
        };

    public int Count(SymptomPriority priority) => _symptoms[priority].Count;

    private Symptom PickSymptom(SymptomPriority priority, int upTo) {
        return _symptoms[priority][_random.Next(Math.Min(upTo, _symptoms[priority].Count))];
    }

    private SymptomPriority PickPriority(SymptomPriority[] allowed) =>
        allowed[_random.Next(allowed.Length)];

    public List<Symptom> GetRandom(
            int count,
            HashSet<Symptom> picked,
            Dictionary<SymptomPriority, int> availability,
            SymptomPriority[] allowed
        )
    {
        var available = allowed.Where(p => availability[p] > 0).ToArray();
        while (picked.Count < count)
        {
            var priority = PickPriority(available);
            var symptom = PickSymptom(priority, availability[priority]);
            picked.Add(symptom);
        }

        return picked.ToList();
    }

    public List<Symptom> PickSymptoms(Scenario sc, Dictionary<SymptomPriority, int> availability) {
        HashSet<Symptom> picked = new();
        switch (sc)
        {
            case Scenario.HighPriority:
                picked.Add(PickSymptom(
                    SymptomPriority.HighPriority,
                    availability[SymptomPriority.HighPriority]
                ));
                GetRandom(4, picked, availability, new [] {
                    SymptomPriority.HighPriority,
                    SymptomPriority.MediumPriority, SymptomPriority.NonFactor,
                    SymptomPriority.RiskFactor, SymptomPriority.NonPriority});
                break;
            case Scenario.RiskFactorMedium:
                picked.Add(PickSymptom(
                    SymptomPriority.RiskFactor,
                    availability[SymptomPriority.RiskFactor]
                ));
                picked.Add(PickSymptom(
                    SymptomPriority.MediumPriority,
                    availability[SymptomPriority.MediumPriority]
                ));
                GetRandom(4, picked, availability, new [] {
                    SymptomPriority.MediumPriority, SymptomPriority.NonFactor,
                    SymptomPriority.RiskFactor, SymptomPriority.NonPriority});
                break;
            case Scenario.ThreeMedium:
                GetRandom(3, picked, availability, new [] { SymptomPriority.MediumPriority });
                GetRandom(4, picked, availability, new [] { SymptomPriority.NonFactor, SymptomPriority.NonPriority });
                break;
            case Scenario.Healthy:
                GetRandom(4, picked, availability, new [] { SymptomPriority.NonFactor, SymptomPriority.NonPriority });
                break;
        }
        return picked.OrderBy(_ => _random.Next()).ToList();
    }
}
