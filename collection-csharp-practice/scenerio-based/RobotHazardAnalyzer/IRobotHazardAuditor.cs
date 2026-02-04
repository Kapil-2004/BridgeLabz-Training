public interface IRobotHazardAuditor
{
    double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState);
}
