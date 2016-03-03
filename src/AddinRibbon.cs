using System.Runtime.InteropServices;
using AddinX.Ribbon.Contract;
using AddinX.Ribbon.Contract.Command;
using AddinX.Ribbon.ExcelDna;

namespace AddinX.Sample.WcfSample
{
    [ComVisible(true)]
    public class AddinRibbon : RibbonFluent
    {
        protected override void CreateFluentRibbon(IRibbonBuilder build)
        {
            build.CustomUi.Ribbon.Tabs(tab =>
                tab.AddTab("Sample").SetId("CustomTab")
                    .Groups(g =>
                    {
                        g.AddGroup("Persons").SetId("SamplePersonGroup")
                            .Items(i =>
                            {
                                i.AddButton("Tom").SetId("TomCmd")
                                    .LargeSize().ImageMso("HappyFace").ShowLabel()
                                    .Screentip("First button for test purpose");

                                i.AddButton("John").SetId("JohnCmd")
                                    .LargeSize().ImageMso("HappyFace").ShowLabel();
                            });
                    }));
        }

        protected override void CreateRibbonCommand(IRibbonCommands cmds)
        {
            cmds.AddButtonCommand("TomCmd")
                .Action(() => AddinContext.MainController.SayHello("Tom"));

            cmds.AddButtonCommand("JohnCmd")
                .Action(() => AddinContext.MainController.SayHello("John"));
        }

        public override void OnClosing()
        {
            AddinContext.Container.Dispose();
            AddinContext.Container = null;

            AddinContext.MainController.Dispose();
        }

        public override void OnOpening() { }


    }
}