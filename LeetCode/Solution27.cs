namespace LeetCode;

public class Solution27
{
    public int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
    {
        int minExperience = 0, sum = 0;
        int len = energy.Length;
        for (int i = 0; i < len; i++)
        {
            sum += energy[i];
            if (initialExperience > experience[i])
            {
                initialExperience += experience[i];
            }
            else
            {
                minExperience += (experience[i] - initialExperience + 1);
                initialExperience += (experience[i] - initialExperience + 1 + experience[i]);
            }
        }

        return (initialEnergy <= sum ? sum + 1 - initialEnergy : 0) + minExperience;
    }
}