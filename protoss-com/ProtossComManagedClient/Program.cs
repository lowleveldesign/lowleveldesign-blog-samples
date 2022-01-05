using ProtossLib;

public static class Program
{
    static void ShowGameUnitData(IGameObject go)
    {
        Console.WriteLine($"Name: {go.Name}, minerals: {go.Minerals}, build time: {go.BuildTime}");
    }

    static void TestCom()
    {
        var nexus = new NexusClass();
        ShowGameUnitData(nexus);

        var probe = nexus.CreateUnit("Probe");
        ShowGameUnitData((IGameObject)probe);

        //_ = Marshal.ReleaseComObject(nexus);
        //_ = Marshal.ReleaseComObject(probe);
    }

    [STAThread]
    static void Main()
    {
        TestCom();

        // force release of the COM objects
        GC.Collect();
    }
}
