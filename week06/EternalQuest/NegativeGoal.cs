// EXCEEDING REQUIREMENTS: NegativeGoal class allows tracking bad habits that deduct points when recorded.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Subtracts points for negative habits
        return -_points;
    }

    public override bool IsComplete()
    {
        return false; // Negative habits are ongoing checks
    }

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- [Penalizes: -{_points} pts]";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}