using HugsLib;
using RimWorld;

[DefOf]
public static class RWPDefs
{
    public static WorkGiverDef DoctorRescueHumanColonist;
    public static WorkGiverDef DoctorTreatHumanColonist;
    public static WorkGiverDef HaulRottable;
    public static WorkGiverDef HaulDeteriorating;
}

public class RWPMenu : ModBase
{
    public override string ModIdentifier
    {
        get
        {
            return "RefactoredWorkPriorities";
        }
    }

    public override void DefsLoaded()
    {
        UpdateDefs();
    }

    public override void SettingsChanged()
    {
        UpdateDefs();
    }

    private void UpdateDefs()
    {
        var customDoctor = Settings.GetHandle<bool>("CustomDoctorPriorities", "Custom Doctor priorities", "Doctors will rescue and treat colonists before animals or outsiders.", true);
        RWPDefs.DoctorRescueHumanColonist.scanThings = customDoctor.Value;
        RWPDefs.DoctorTreatHumanColonist.scanThings = customDoctor.Value;

        var customHaul = Settings.GetHandle<bool>("CustomHaulPriorities", "Custom Haul priorities", "Haulers will haul rottable items (corn, meals etc.) and items which deteriorate over time (weapons, wood etc.) before generic things.", true);
        RWPDefs.HaulRottable.scanThings = customHaul.Value;
        RWPDefs.HaulDeteriorating.scanThings = customHaul.Value;
    }
}