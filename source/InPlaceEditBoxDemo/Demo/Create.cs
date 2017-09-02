﻿namespace InPlaceEditBoxDemo.Demo
{
    using SolutionLib.Interfaces;
    using SolutionLib.Models;
    using System.Collections.Generic;

    internal class Create
    {
        internal static void Objects(ISolution solutionRoot)
        {
            var root = solutionRoot.AddSolutionRootItem("Microsoft Projects");
            root.IsItemExpanded = true;

            var xmlFolder = solutionRoot.AddRootChild("XML", SolutionItemType.Folder);
            xmlFolder.IsItemExpanded = true;

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            var newTest = new CreateTestObject("Open-XML-SDK"
                            ,new string []{ "BinaryFormatConverter"
                                                ,"DocumentFormat.OpenXml.Tests"
                                                ,"DocumentFormat.OpenXml"
                                                ,"build"},
                            new string[] {  ".gitattributes"
                                                ,".gitignore"
                                                ,"DocumentFormat.OpenXml.snk"
                                                ,"GitVersion.yml"
                                                ,"LICENSE.txt"
                                                ,"Open-XML-SDK.sln"
                                                ,"README.md"
                                                ,"appveyor.yml"
                                                ,"dir.props"
                                                ,"dir.targets" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);

            var lastItem = xmlFolder.FindChild("Open-XML-SDK");
            if (lastItem != null)
            {
                lastItem.IsItemExpanded = true;

                lastItem = lastItem.FindChild("DocumentFormat.OpenXml.Tests");
                if (lastItem != null)
                {
                    lastItem.IsItemExpanded = true;

                    lastItem = lastItem.FindChild("file_99");
                    if (lastItem != null)
                    {
                        lastItem.IsItemSelected = true;
                    }
                }
            }

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("XmlNotePad"
                            , new string[]{ "images"
                                           ,"src"},
                            new string[] {  ".gitattributes"
                                            ,".gitignore"
                                            ,"LICENSE"
                                            ,"README.md" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("OpenXml"
                            , new string[]{ "Libs"
                                           ,"WordToHtml", "ZipHelper"},
                            new string[] {  ".gitattributes"
                                            ,".gitignore"
                                            ,"LICENSE"
                                            ,"OpenXml.sln"
                                            ,"README.md" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);
            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("Microsoft_Virtual_Academy_Xml_To_Srt"
                            , new string[]{ "MVAXml2Subs.Tests"
                                           ,"MVAXml2Subs"},
                            new string[] {  ".gitattributes"
                                            ,".gitignore"
                                            ,"LICENSE"
                                            ,"MVAXml2Subs.sln"
                                            ,"README.md" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("Xml2Markdown"
                            , new string[]{ "Xml2Markdown" },
                            new string[] {  ".gitattributes"
                                            ,".gitignore"
                                            ,"LICENSE"
                                            ,"Xml2Markdown.sln"
                                            ,"README.md" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("OpenXmlDocumentLibrary"
                            , new string[] { "OpenXmlDocumentLibrary", "OpenXmlLibrary.Tests" },
                            new string[] {  ".gitattributes"
                                            ,".gitignore"
                                            ,"changelog.md"
                                            ,"OpenXmlLibrary.sln"
                                            ,"README.md" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("XslTransformer"
                            , new string[] { "XslTransformer.Core", "XslTransformer" },
                            new string[] {  ".gitattributes"
                                            ,".gitignore"
                                            ,"LICENSE"
                                            ,"XslTransformer.sln"
                                            ,"README.md" }
            );

            CreateProject(solutionRoot, newTest.Project, xmlFolder, newTest.Folders, newTest.Files);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("vscode"
                            , new string[] { "build", "extensions", "i18n", "resources"
                                           , "scripts", "src", "test" },
                            null);

            CreateProject(solutionRoot, newTest.Project, root, newTest.Folders, newTest.Files);

            // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
            newTest = new CreateTestObject("msbuild"
                            , new string[] { "Samples", "branding", "build", "documentation"
                                           , "ref", "setup", "src", "targets" },
                            null);

            CreateProject(solutionRoot, newTest.Project, root, newTest.Folders, newTest.Files);

            string[] Projects = { "AvalonEdit", "AvalonDock", "Edi", "XmlNotePad", "XmlViewer", "MRULib", "MLib", "Visual Studio" };

            foreach (var item in Projects)
            {
                CreateProject(solutionRoot, item, root, null, null);
           }
        }

        /// <summary>
        /// Creates a mockup project structure with items below it.
        /// </summary>
        /// <param name="solutionRoot"></param>
        /// <param name="project"></param>
        /// <param name="parent"></param>
        /// <param name="folders"></param>
        /// <param name="files"></param>
        private static void CreateProject(
            ISolution solutionRoot
            , string project
            , ISolutionBaseItem parent
            , List<string> folders
            , List<string> files
            )
        {
            var projectItem = solutionRoot.AddChild(project, SolutionItemType.Project, parent);
            var projectItemChanged = false;

            for (int i = 0; i < 13; i++)
            {
                solutionRoot.AddChild(string.Format("file_{0}", i), SolutionItemType.File, projectItem);
                projectItemChanged = true;
            }


            if (folders != null)
            {
                foreach (var item in folders)
                {
                    var folder = solutionRoot.AddChild(item, SolutionItemType.Folder, projectItem);

                    for (int i = 0; i < 123; i++)
                    {
                        solutionRoot.AddChild(string.Format("file_{0}",i), SolutionItemType.File, folder);
                        projectItemChanged = true;
                    }
                }
            }

            if (files != null)
            {
                foreach (var item in files)
                    solutionRoot.AddChild(item,SolutionItemType.File , projectItem);

                projectItemChanged = true;
            }

            parent.SortChildren();

            if (projectItemChanged == true)
                projectItem.SortChildren();
        }
    }
}
