using UnrealBuildTool;

public class XSJAssetToolsEditor : ModuleRules
{
	public XSJAssetToolsEditor(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				"ToolMenus",
				"UnrealEd",
				"XSJArtToolsCore"
			}
		);
	}
}
