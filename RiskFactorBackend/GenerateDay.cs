namespace RiskFactorBackend;

public enum Scenario {
    HighPriority,
    RiskFactorMedium,
    ThreeMedium,
    Healthy,
    RiskFactorOnly,
    FewMedium
}

public class GenerateDay {
    public const int PatientsPerDay = 5;

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

    private Scenario PickHealthyScenario(int day) {
        var options = new List<Scenario> { Scenario.Healthy };
        if (dayAvails[day][SymptomPriority.MediumPriority] > 0)
            options.Add(Scenario.FewMedium);
        if (dayAvails[day][SymptomPriority.RiskFactor] > 0)
            options.Add(Scenario.RiskFactorOnly);
        return options[_random.Next(options.Count)];
    }

    public List<List<String>> Symptoms(int day) {
        int d = Math.Clamp(day, 1, dayAvails.Keys.Max());
        List<List<String>> people = new();
        int unhealthyCount = _random.Next(PatientsPerDay / 2, (int)(PatientsPerDay * 0.9));
        int healthyCount = PatientsPerDay - unhealthyCount;
        for (int i = 0; i < healthyCount; i++) {
            List<String> info = new() { "Healthy" };
            List<Symptom> symptoms = _bank.PickSymptoms(PickHealthyScenario(d), dayAvails[d]);
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
            List<Symptom> symptoms = _bank.PickSymptoms(sc, dayAvails[d]);
            foreach (var symptom in symptoms) {
                string dialogue = symptom.DialogueOptions[_random.Next(symptom.DialogueOptions.Length)];
                info.Add(dialogue);
            }
            people.Add(info);
        }
        return people.OrderBy(_ => _random.Next()).ToList();
    }

    public Dictionary<string, List<string>> SymptomList(int day) {
        int d = Math.Clamp(day, 1, dayAvails.Keys.Max());
        var avails = dayAvails[d];
        return new Dictionary<string, List<string>> {
            ["high_priority"]   = _bank.GetRange(SymptomPriority.HighPriority,   0, avails[SymptomPriority.HighPriority])  .Select(s => s.Name).ToList(),
            ["medium_priority"] = _bank.GetRange(SymptomPriority.MediumPriority, 0, avails[SymptomPriority.MediumPriority]).Select(s => s.Name).ToList(),
            ["risk_factor"]     = _bank.GetRange(SymptomPriority.RiskFactor,     0, avails[SymptomPriority.RiskFactor])    .Select(s => s.Name).ToList(),
        };
    }

    public string DayInfo(int day) {
        string info = $"=== DAY {day}: ===\n";
        switch (day) {
            case 1:
                info += "NEW FEATURE: \nThe patient MUST be sent to the hospital if they have even one HIGH PRIORITY symptom.\n";
                break;
            case 2:
                info += "NEW FEATURE: \nPatients must have at least 3 MEDIUM PRIORITY symptoms to be sent to the hospital.\n";
                break;
            case 3:
                info += "NEW FEATURE: \nIf a patient has at least 1 RISK FACTOR, only 1 MEDIUM PRIORITY symptom is needed to send them to the hospital.\n";
                break;
            case 5:
                info += "NEW FEATURE: \nYou now must make a decision within a time limit! The time limit will decrease as days go on.\n";
                break;
        }

        var labels = new (SymptomPriority priority, string label)[] {
            (SymptomPriority.RiskFactor,     "RISK FACTOR"),
            (SymptomPriority.MediumPriority, "MEDIUM PRIORITY"),
            (SymptomPriority.HighPriority,   "HIGH PRIORITY"),
        };

        int maxDay = dayAvails.Keys.Max();
        int dc = Math.Clamp(day, 1, maxDay);
        int prev = Math.Clamp(day - 1, 1, maxDay);

        string symptomInfo = "";
        foreach (var (priority, label) in labels) {
            int from = day > 1 ? dayAvails[prev][priority] : 0;
            int to = dayAvails[dc][priority];
            if (to <= from) continue;
            var newSymptoms = _bank.GetRange(priority, from, to);
            symptomInfo += $"\nNEW {label} SYMPTOMS:\n";
            foreach (var symptom in newSymptoms)
                symptomInfo += $" • {symptom.Name} --- {symptom.Description}\n";
        }

        info += symptomInfo.Length > 0 ? symptomInfo : "No new information. Let's get to treating!";
        return info;
    }

}