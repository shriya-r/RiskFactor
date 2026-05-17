namespace RiskFactorBackend;

public enum Scenario {
    HighPriority,
    RiskFactorMedium,
    ThreeMedium,
    Healthy
}

public class GenerateDay {
    private readonly Random _random = new();
    private readonly SymptomBank _bank;
    private readonly Dictionary<int, Dictionary<SymptomPriority, int>> dayAvails;

    public GenerateDay(SymptomBank bank) {
        _bank = bank;
        dayAvails = new()
        {
            [1] = new()
            {
                [SymptomPriority.HighPriority]   = 2,
                [SymptomPriority.MediumPriority] = 0,
                [SymptomPriority.NonPriority]    = bank.Count(SymptomPriority.NonPriority),
                [SymptomPriority.RiskFactor]     = 0,
                [SymptomPriority.NonFactor]      = bank.Count(SymptomPriority.NonFactor),
            },
            [2] = new()
            {
                [SymptomPriority.HighPriority]   = 4,
                [SymptomPriority.MediumPriority] = 3,
                [SymptomPriority.NonPriority]    = bank.Count(SymptomPriority.NonPriority),
                [SymptomPriority.RiskFactor]     = 0,
                [SymptomPriority.NonFactor]      = bank.Count(SymptomPriority.NonFactor),
            },
            [3] = new()
            {
                [SymptomPriority.HighPriority]   = bank.Count(SymptomPriority.HighPriority),
                [SymptomPriority.MediumPriority] = 6,
                [SymptomPriority.NonPriority]    = bank.Count(SymptomPriority.NonPriority),
                [SymptomPriority.RiskFactor]     = 2,
                [SymptomPriority.NonFactor]      = bank.Count(SymptomPriority.NonFactor),
            },
            [4] = new()
            {
                [SymptomPriority.HighPriority]   = bank.Count(SymptomPriority.HighPriority),
                [SymptomPriority.MediumPriority] = 9,
                [SymptomPriority.NonPriority]    = bank.Count(SymptomPriority.NonPriority),
                [SymptomPriority.RiskFactor]     = 5,
                [SymptomPriority.NonFactor]      = bank.Count(SymptomPriority.NonFactor),
            },
            [5] = new()
            {
                [SymptomPriority.HighPriority]   = bank.Count(SymptomPriority.HighPriority),
                [SymptomPriority.MediumPriority] = bank.Count(SymptomPriority.MediumPriority),
                [SymptomPriority.NonPriority]    = bank.Count(SymptomPriority.NonPriority),
                [SymptomPriority.RiskFactor]     = bank.Count(SymptomPriority.RiskFactor),
                [SymptomPriority.NonFactor]      = bank.Count(SymptomPriority.NonFactor),
            },
        };
    }

    public List<List<String>> Symptoms(int day) {
        List<List<String>> people = new();
        int unhealthyCount = _random.Next(5,9);
        int healthyCount = 10 - unhealthyCount;
        for (int i = 0; i < healthyCount; i++) {
            List<String> info = new() { "Healthy" };
            List<Symptom> symptoms = _bank.PickSymptoms(Scenario.Healthy, dayAvails[day]);
            foreach (var symptom in symptoms) {
                string dialogue = symptom.DialogueOptions[_random.Next(symptom.DialogueOptions.Length)];
                info.Add(dialogue);
            }
            people.Add(info);
        }
        for (int i = 0; i < unhealthyCount; i++) {
            List<String> info = new() { "Unhealthy" };
            Scenario sc = default;
            switch (day) {
                case 1:
                    sc = Scenario.HighPriority;
                    break;
                case 2:
                    sc = _random.Next(2) == 0 ? Scenario.HighPriority : Scenario.ThreeMedium;
                    break;
                default:
                    sc = Enum.GetValues<Scenario>()[_random.Next(3)];
                    break;
            }
            List<Symptom> symptoms = _bank.PickSymptoms(sc, dayAvails[day]);
            foreach (var symptom in symptoms) {
                string dialogue = symptom.DialogueOptions[_random.Next(symptom.DialogueOptions.Length)];
                info.Add(dialogue);
            }
            people.Add(info);
        }
        return people.OrderBy(_ => _random.Next()).ToList();
    }
}