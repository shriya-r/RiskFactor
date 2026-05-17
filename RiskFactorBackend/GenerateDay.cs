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

    public string DayInfo(int day) {
        string info = $"Day {day}:\n";
        switch (day) {
            case 1:
                info += "NEW FEATURE: The patient MUST be sent to the hospital if they have even one HIGH priority symptom.\n";
                break;
            case 2:
                info += "NEW FEATURE: Patients must have at least 3 MEDIUM priority symptoms to be sent to the hospital.\n";
                break;
            case 3:
                info += "NEW FEATURE: If a patient has at least 1 RISK FACTOR, only 1 MEDIUM priority symptom is needed to send them to the hospital.\n";
                break;
        }

        var labels = new (SymptomPriority priority, string label)[] {
            (SymptomPriority.RiskFactor,     "RISK FACTOR"),
            (SymptomPriority.MediumPriority, "MEDIUM Priority"),
            (SymptomPriority.HighPriority,   "HIGH Priority"),
        };

        string symptomInfo = "";
        foreach (var (priority, label) in labels) {
            int from = day > 1 ? dayAvails[day - 1][priority] : 0;
            int to = dayAvails[day][priority];
            if (to <= from) continue;
            var newSymptoms = _bank.GetRange(priority, from, to);
            symptomInfo += $"\nNew {label} symptoms:\n";
            foreach (var symptom in newSymptoms)
                symptomInfo += $"{symptom.Name} - {symptom.Description}\n";
        }

        info += symptomInfo.Length > 0 ? symptomInfo : "No new information. Let's get to treating!";
        return info;
    }
}