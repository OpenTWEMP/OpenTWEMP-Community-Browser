using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using TWE_Launcher.Models;
using TWE_Launcher.Properties;
using TWE_Launcher.Sources.Models.Localizations;

namespace TWE_Launcher.Forms
{
	public partial class MainLauncherForm : Form, ICanChangeMyLocalization
	{
		public RadioButton LauncherProviderControl_M2TWEOP => radioButtonLauncherProvider_M2TWEOP;
		public RadioButton LauncherProviderControl_NativeSetup => radioButtonLauncherProvider_NativeSetup;
		public RadioButton LauncherProviderControl_BatchScript => radioButtonLauncherProvider_BatchScript;
		public RadioButton LauncherProviderControl_TWEMP => radioButtonLauncherProvider_TWEMP;


		public RadioButton RadioButton_FullScreenMode => radioButtonLaunchFullScreen;
		public RadioButton RadioButton_WindowedMode => radioButtonLaunchWindowScreen;
		public CheckBox CheckBox_Video => checkBoxVideo;
		public CheckBox CheckBox_Borderless => checkBoxBorderless;

		public RadioButton RadioButton_LogErrorAndTrace => radioButtonLogErrorAndTrace;

		public RadioButton RadioButton_LogOnlyTrace => radioButtonLogOnlyTrace;
		public RadioButton RadioButton_LogOnlyError => radioButtonLogOnlyError;

		public CheckBox CheckBox_Cleaner_MapRWM => checkBoxCleaner_MapRWM;
		public CheckBox CheckBox_Cleaner_textBIN => checkBoxCleaner_textBIN;
		public CheckBox CheckBox_Cleaner_soundPacks => checkBoxCleaner_soundPacks;

		public CheckBox CheckBox_LogHistory => checkBoxLogHistory;


		public MainLauncherForm()
		{
			InitializeComponent();

			SetupCurrentLocalizationForGUIControls();

			UpdateModificationsTreeView();

			Text = GetApplicationFullName();
		}

		private static string GetApplicationFullName()
		{
			string appProjectTitle = "OpenTWEMP Community Browser";
			string appHomeFolder = Application.ExecutablePath;

			return appProjectTitle + " [ " + appHomeFolder + " ]";
		}


		public void ApplyExperimentalChanges(bool isEnabledChangesStatus)
		{
			groupBoxLauncherProviders.Visible = isEnabledChangesStatus;
			radioButtonLauncherProvider_TWEMP.Checked = true;
			Program.UseExperimentalFeatures = isEnabledChangesStatus;
		}


		public void UpdateModificationsTreeView()
		{
			treeViewGameMods.Enabled = false;

			Settings.UpdateTotalModificationsList();

			UpdateAllModificationsInTreeView();
			UpdateCustomCollectionsInTreeView();
			UpdateFavoriteCollectionInTreeView();

			DisableModUIControls();

			treeViewGameMods.Enabled = true;
		}

		private void UpdateFavoriteCollectionInTreeView()
		{
			TreeNode favoriteCollectionNode = treeViewGameMods.Nodes[0];
			favoriteCollectionNode.Nodes.Clear();
			CreateFavoriteCollectionChildNodes(Settings.FavoriteModsCollection, favoriteCollectionNode);
		}

		private void CreateFavoriteCollectionChildNodes(CustomModsCollection favoriteCollection, TreeNode favoriteCollectionRootNode)
		{
			foreach (KeyValuePair<string, string> modPair in favoriteCollection.Modifications)
			{
				var modNode = CreateCollectionChildNode(modPair.Value);
				favoriteCollectionRootNode.Nodes.Add(modNode);
			}
		}



		public void UpdateCustomCollectionsInTreeView()
		{
			TreeNode customCollectionsNode = treeViewGameMods.Nodes[1];
			customCollectionsNode.Nodes.Clear();

			foreach (CustomModsCollection collection in Settings.UserCollections)
			{
				CreateCollectionNodeWithChilds(collection, customCollectionsNode);
			}
		}

		private void CreateCollectionNodeWithChilds(CustomModsCollection collection, TreeNode collectionsParentNode)
		{
			var collectionNode = CreateCollectionParentNode(collection);

			foreach (KeyValuePair<string, string> modPair in collection.Modifications)
			{
				var modNode = CreateCollectionChildNode(modPair.Value);
				collectionNode.Nodes.Add(modNode);
			}

			collectionsParentNode.Nodes.Add(collectionNode);
		}

		private TreeNode CreateCollectionParentNode(CustomModsCollection collection)
		{
			return new TreeNode(collection.Name);
		}

		private TreeNode CreateCollectionChildNode(string childNodeText)
		{
			var childNode = new TreeNode(childNodeText);
			childNode.NodeFont = new Font("Segoe UI Historic", 10F, FontStyle.Regular, GraphicsUnit.Point);
			return childNode;
		}

		private void UpdateAllModificationsInTreeView()
		{
			TreeNode allModsNode = treeViewGameMods.Nodes[2];
			allModsNode.Nodes.Clear();

			List<GameSetupInfo> gameInstallations = Settings.GameInstallations;
			foreach (GameSetupInfo gameInstallation in gameInstallations)
			{
				TreeNode gameInstallationNode = new TreeNode(gameInstallation.Name);
				allModsNode.Nodes.Add(gameInstallationNode);

				List<ModCenterInfo> modCenters = gameInstallation.AttachedModCenters;
				foreach (ModCenterInfo modcenter in modCenters)
				{
					TreeNode modcenterNode = new TreeNode(modcenter.Name);
					gameInstallationNode.Nodes.Add(modcenterNode);

					List<GameModificationInfo> mods = modcenter.InstalledModifications;
					foreach (GameModificationInfo mod in mods)
					{
						TreeNode modNode = CreateCollectionChildNode(mod.ShortName);
						modcenterNode.Nodes.Add(modNode);
					}
				}
			}
		}

		private void treeViewGameMods_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (IsNotModificationNode(e.Node))
			{
				ChangeSelectedNodeView(e.Node);
				DisableModUIControls();
				return;
			}
			else
			{
				if (IsNodeOfFavoriteCollection(e.Node) || 
						IsNodeOfModificationFromCustomCollection(e.Node) ||
							IsNodeOfModificationFromAllModsCollection(e.Node))
				{
					GameModificationInfo selectedModification = FindModBySelectedNodeFromCollection(e.Node);

					selectedModification.ShowModVisitingCard(modLogoPictureBox, modStatusLabel);

					if (Program.UseExperimentalFeatures)
					{
						modMainTitleLabel.Text = selectedModification.CurrentPreset.ModTitle;

						if (selectedModification.CanBeLaunchedViaNativeBatch())
						{
							radioButtonLauncherProvider_BatchScript.Enabled = true;
							ColorTheme currentColorTheme = ColorTheme.SelectColorThemeByStyle(Program.CurrentGUIStyle);
							radioButtonLauncherProvider_BatchScript.ForeColor = currentColorTheme.CommonControlsForeColor;
						}
						else
						{
							radioButtonLauncherProvider_BatchScript.Enabled = false;
							radioButtonLauncherProvider_BatchScript.ForeColor = Color.DarkRed;
						}

						if (selectedModification.CanBeLaunchedViaNativeSetup())
						{
							radioButtonLauncherProvider_NativeSetup.Enabled = true;
							ColorTheme currentColorTheme = ColorTheme.SelectColorThemeByStyle(Program.CurrentGUIStyle);
							radioButtonLauncherProvider_NativeSetup.ForeColor = currentColorTheme.CommonControlsForeColor;
						}
						else
						{
							radioButtonLauncherProvider_NativeSetup.Enabled = false;
							radioButtonLauncherProvider_NativeSetup.ForeColor = Color.DarkRed;
						}

						if (selectedModification.CanBeLaunchedViaM2TWEOP())
						{
							radioButtonLauncherProvider_M2TWEOP.Enabled = true;
							ColorTheme currentColorTheme = ColorTheme.SelectColorThemeByStyle(Program.CurrentGUIStyle);
							radioButtonLauncherProvider_M2TWEOP.ForeColor = currentColorTheme.CommonControlsForeColor;
						}
						else
						{
							radioButtonLauncherProvider_M2TWEOP.Enabled = false;
							radioButtonLauncherProvider_M2TWEOP.ForeColor = Color.DarkRed;
						}
					}
					else
					{
						modMainTitleLabel.Text = selectedModification.ShortName;
					}

					EnableModUIControls();
					return;
				}
			}
		}


		private bool IsNotModificationNode(TreeNode node)
		{
			// Is 'node' is selected on the Collection Level ?

			if (IsRootNodeOfTreeView(node))
			{
				return true;
			}

			// Is 'node' is selected on the Custom Collection Folders Level ?

			if (IsCustomCollectionFolderNode(node))
			{
				return true;
			}

			// Is 'node' is selected on the GameSetup Node Level ?

			if (IsGameSetupNode(node))
			{
				return true;
			}

			// Is 'node' is selected on the ModCentet Node Level ?

			if (IsModCenterNode(node))
			{
				return true;
			}

			return false;
		}


		private bool IsRootNodeOfTreeView(TreeNode node)
		{
			return (node.Level == 0);
		}

		private bool IsCustomCollectionFolderNode(TreeNode node)
		{
			return ((node.Level == 1) && node.Parent.Text.Equals("My Mod Collections"));
		}

		private bool IsGameSetupNode(TreeNode node)
		{
			return ((node.Level == 1) && node.Parent.Text.Equals("All Modifications"));
		}

		private bool IsModCenterNode(TreeNode node)
		{
			return ((node.Level == 2) && (node.Parent).Parent.Text.Equals("All Modifications"));
		}

		private bool IsNodeOfFavoriteCollection(TreeNode node)
		{
			if (node.Level == 1)
			{
				if (node.Parent.Text.Equals("My Favorite Mods"))
				{
					return true;
				}
			}

			return false;
		}

		private bool IsNodeOfModificationFromCustomCollection(TreeNode node)
		{
			if (node.Level == 2)
			{
				TreeNode currentCollection = node.Parent;

				if (currentCollection.Parent.Text.Equals("My Mod Collections"))
				{
					return true;
				}
			}

			return false;
		}

		private bool IsNodeOfModificationFromAllModsCollection(TreeNode node)
		{
			if (node.Level == 3)
			{
				TreeNode currentModCenterNode = node.Parent;
				TreeNode currentGameSetupNode = currentModCenterNode.Parent;

				if (currentGameSetupNode.Parent.Text.Equals("All Modifications"))
				{
					return true;
				}
			}

			return false;
		}

		private GameModificationInfo FindModBySelectedNodeFromCollection(TreeNode selectedTreeNode)
		{
			return Settings.GetActiveModificationInfo(selectedTreeNode.Text);
		}

		private GameModificationInfo FindModificationBySelectedTreeNode(TreeNode selectedTreeNode)
		{
			TreeNode modcenterNode = selectedTreeNode.Parent;
			TreeNode gamesetupNode = modcenterNode.Parent;

			GameSetupInfo currentGameSetup = Settings.GameInstallations.Find(gamesetup => gamesetup.Name.Equals(gamesetupNode.Text));
			ModCenterInfo currentModCenter = currentGameSetup.AttachedModCenters.Find(modcenter => modcenter.Name.Equals(modcenterNode.Text));

			return currentModCenter.InstalledModifications[selectedTreeNode.Index];
		}


		private void ChangeSelectedNodeView(TreeNode node)
		{
			if (node.IsExpanded)
			{
				node.Collapse();
			}
			else
			{
				node.Expand();
			}
		}



		// MODS COLLECTIONS MANAGEMENT

		private void buttonMarkFavoriteMod_Click(object sender, EventArgs e)
		{
			TreeNode modNode = treeViewGameMods.SelectedNode;
			GameModificationInfo selectedModInfo = FindModBySelectedNodeFromCollection(modNode);

			if (IsNodeOfModificationFromAllModsCollection(modNode) || IsNodeOfModificationFromCustomCollection(modNode))
			{
				if (selectedModInfo.IsFavoriteMod)
				{
					MessageBox.Show("This mod is already added to Favorite Mods!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				else
				{
					TreeNode favoriteModNode = CreateCollectionChildNode(selectedModInfo.ShortName);

					TreeNode allFavoriteModsNode = treeViewGameMods.Nodes[0];
					allFavoriteModsNode.Nodes.Add(favoriteModNode);

					selectedModInfo.IsFavoriteMod = true;
					Settings.FavoriteModsCollection.Modifications.Add(selectedModInfo.Location, selectedModInfo.ShortName);
					CustomModsCollection.WriteFavoriteCollection();

					MessageBox.Show("This mod was successfully ADDED to Favorite Mods!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
			}

			if (IsNodeOfFavoriteCollection(modNode))
			{
				TreeNode favoriteModsNode = treeViewGameMods.Nodes[0];

				foreach (TreeNode node in favoriteModsNode.Nodes)
				{
					if (node.Text.Equals(modNode.Text))
					{
						favoriteModsNode.Nodes.Remove(node);

						selectedModInfo.IsFavoriteMod = false;
						Settings.FavoriteModsCollection.Modifications.Remove(selectedModInfo.Location);
						CustomModsCollection.WriteFavoriteCollection();

						MessageBox.Show("This mod was successfully REMOVED from Favorite Mods!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}
				}
			}
		}


		private void buttonCollectionCreate_Click(object sender, EventArgs e)
		{
			var collectionCreateForm = new CollectionCreateForm(this);
			collectionCreateForm.Show();
		}

		public void CreateModsCollectionTreeView(CustomModsCollection collection)
		{
			TreeNode customCollectionsRootNode = treeViewGameMods.Nodes[1];
			TreeNode createdCollectionNode = customCollectionsRootNode.Nodes.Add(collection.Name);

			foreach (KeyValuePair<string, string> modification in collection.Modifications)
			{
				TreeNode modChildNode = CreateCollectionChildNode(modification.Value);
				createdCollectionNode.Nodes.Add(modChildNode);
			}
		}

		private void buttonCollectionManage_Click(object sender, EventArgs e)
		{
			var collectionManageForm = new CollectionManageForm(this);
			collectionManageForm.Show();
		}


		private void DisableModUIControls()
		{
			groupBoxLauncherProviders.Enabled = false;
			groupBoxLauncherProviders.Visible = false;

			groupBoxConfigProfiles.Enabled = false;
			groupBoxConfigProfiles.Visible = false;

			groupBoxConfigLaunchMode.Enabled = false;
			groupBoxConfigLaunchMode.Visible = false;

			groupBoxConfigLogMode.Enabled = false;
			groupBoxConfigLogMode.Visible = false;

			groupBoxConfigCleanerMode.Enabled = false;
			groupBoxConfigCleanerMode.Visible = false;

			buttonLaunch.Enabled = false;
			buttonLaunch.Visible = false;

			buttonExplore.Enabled = false;
			buttonExplore.Visible = false;

			modQuickNavigationButton.Enabled = false;
			modQuickNavigationButton.Visible = false;

			buttonMarkFavoriteMod.Enabled = false;
			buttonMarkFavoriteMod.Visible = false;

			modMainTitleLabel.Text = string.Empty;
			modStatusLabel.Text = string.Empty;

			if (modLogoPictureBox.Image != null)
			{
				modLogoPictureBox.Image.Dispose();
				modLogoPictureBox.Image = Resources.BROWSER_LOGO;
			}
		}

		private void EnableModUIControls()
		{
			groupBoxLauncherProviders.Enabled = true;
			groupBoxLauncherProviders.Visible = true;

			groupBoxConfigProfiles.Enabled = true;
			groupBoxConfigProfiles.Visible = true;

			groupBoxConfigLaunchMode.Enabled = true;
			groupBoxConfigLaunchMode.Visible = true;

			groupBoxConfigLogMode.Enabled = true;
			groupBoxConfigLogMode.Visible = true;

			groupBoxConfigCleanerMode.Enabled = true;
			groupBoxConfigCleanerMode.Visible = true;

			buttonLaunch.Enabled = true;
			buttonLaunch.Visible = true;

			buttonExplore.Enabled = true;
			buttonExplore.Visible = true;

			modQuickNavigationButton.Enabled = true;
			modQuickNavigationButton.Visible = true;

			buttonMarkFavoriteMod.Enabled = true;
			buttonMarkFavoriteMod.Visible = true;
		}

		private void changeLauncherGUIWhenGameStarting()
		{
			WindowState = FormWindowState.Minimized;
			ShowInTaskbar = false;
		}

		private void changeLauncherGUIWhenGameExiting()
		{
			ShowInTaskbar = true;
			WindowState = FormWindowState.Normal;
		}


		private void buttonLaunch_Click(object sender, EventArgs e)
		{
			changeLauncherGUIWhenGameStarting();

			TreeNode modNode = treeViewGameMods.SelectedNode;

			GameModificationInfo targetModInfo;

			if (IsNodeOfFavoriteCollection(modNode) || IsNodeOfModificationFromCustomCollection(modNode))
			{
				targetModInfo = FindModBySelectedNodeFromCollection(modNode);

			}
			else if (IsNodeOfModificationFromAllModsCollection(modNode))
			{
				targetModInfo = FindModificationBySelectedTreeNode(modNode);
			}
			else
			{
				targetModInfo = null;
				MessageBox.Show("ERROR: Cannot execute this MOD !!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var launchConfiguration = new LaunchConfiguration(targetModInfo, new CustomConfigState(this));
			launchConfiguration.Execute();

			changeLauncherGUIWhenGameExiting();
		}

		private void modQuickNavigationButton_Click(object sender, EventArgs e)
		{
			GameModificationInfo currentMod = FindModBySelectedNodeFromCollection(treeViewGameMods.SelectedNode);
			var form = new ModQuickNavigatorForm(currentMod.Location);
			form.ShowDialog();
		}

		private void buttonExplore_Click(object sender, EventArgs e)
		{
			GameModificationInfo current_mod_info = FindModBySelectedNodeFromCollection(treeViewGameMods.SelectedNode);
			SystemToolbox.ShowFileSystemDirectory(current_mod_info.Location);
		}


		private void modConfigSettingsButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Config Settings");
		}


		// COLOR THEMES FOR THE LAUNCHER


		public void UpdateGUIStyle(GuiStyle style)
		{
			ColorTheme colorTheme = ColorTheme.SelectColorThemeByStyle(style);

			// Set back color for main form.
			BackColor = colorTheme.MainFormBackColor;

			// Set back color for panels.
			panelCollections.BackColor = colorTheme.PanelsBackColor;
			panelLauncherToolkit.BackColor = colorTheme.PanelsBackColor;
			panelLauncherOptions.BackColor = colorTheme.PanelsBackColor;

			// Set back color for mod UI controls.
			treeViewGameMods.BackColor = colorTheme.ModControlsBackColor;
			modMainTitleLabel.BackColor = colorTheme.ModControlsBackColor;
			modStatusLabel.BackColor = colorTheme.ModControlsBackColor;

			// Set back color for common UI controls.
			buttonLaunch.BackColor = colorTheme.CommonControlsBackColor;
			modQuickNavigationButton.BackColor = colorTheme.CommonControlsBackColor;
			buttonExplore.BackColor = colorTheme.CommonControlsBackColor;

			buttonMarkFavoriteMod.BackColor = colorTheme.CommonControlsBackColor;
			buttonCollectionCreate.BackColor = colorTheme.CommonControlsBackColor;
			buttonCollectionManage.BackColor = colorTheme.CommonControlsBackColor;


			// Set fore color for common UI controls.

			buttonLaunch.ForeColor = colorTheme.CommonControlsForeColor;
			modQuickNavigationButton.ForeColor = colorTheme.CommonControlsForeColor;
			buttonExplore.ForeColor = colorTheme.CommonControlsForeColor;

			buttonMarkFavoriteMod.ForeColor = colorTheme.CommonControlsForeColor;
			buttonCollectionCreate.ForeColor = colorTheme.CommonControlsForeColor;
			buttonCollectionManage.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigProfiles.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonConfigProfile_Gaming.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonConfigProfile_Modding.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigLaunchMode.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLaunchWindowScreen.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLaunchFullScreen.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxVideo.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxBorderless.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigLogMode.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLogOnlyError.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLogOnlyTrace.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLogErrorAndTrace.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxLogHistory.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxConfigCleanerMode.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxCleaner_MapRWM.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxCleaner_textBIN.ForeColor = colorTheme.CommonControlsForeColor;
			checkBoxCleaner_soundPacks.ForeColor = colorTheme.CommonControlsForeColor;

			groupBoxLauncherProviders.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLauncherProvider_TWEMP.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLauncherProvider_BatchScript.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLauncherProvider_NativeSetup.ForeColor = colorTheme.CommonControlsForeColor;
			radioButtonLauncherProvider_M2TWEOP.ForeColor = colorTheme.CommonControlsForeColor;

			treeViewGameMods.ForeColor = colorTheme.CommonControlsForeColor;
			modMainTitleLabel.ForeColor = colorTheme.CommonControlsForeColor;
			modStatusLabel.ForeColor = colorTheme.CommonControlsForeColor;
		}


		public void SetupCurrentLocalizationForGUIControls()
		{
			FormLocaleSnapshot snapshot = Program.CurrentLocalization.GetFormLocaleSnapshotByKey(Name);

			buttonLaunch.Text = snapshot.GetLocalizedValueByKey(buttonLaunch.Name);
			modQuickNavigationButton.Text = snapshot.GetLocalizedValueByKey(modQuickNavigationButton.Name);
			buttonExplore.Text = snapshot.GetLocalizedValueByKey(buttonExplore.Name);

			groupBoxConfigCleanerMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigCleanerMode.Name);
			checkBoxCleaner_MapRWM.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_MapRWM.Name);
			checkBoxCleaner_textBIN.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_textBIN.Name);
			checkBoxCleaner_soundPacks.Text = snapshot.GetLocalizedValueByKey(checkBoxCleaner_soundPacks.Name);

			groupBoxConfigLogMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigLogMode.Name);
			radioButtonLogOnlyError.Text = snapshot.GetLocalizedValueByKey(radioButtonLogOnlyError.Name);
			radioButtonLogOnlyTrace.Text = snapshot.GetLocalizedValueByKey(radioButtonLogOnlyTrace.Name);
			radioButtonLogErrorAndTrace.Text = snapshot.GetLocalizedValueByKey(radioButtonLogErrorAndTrace.Name);
			checkBoxLogHistory.Text = snapshot.GetLocalizedValueByKey(checkBoxLogHistory.Name);

			groupBoxConfigLaunchMode.Text = snapshot.GetLocalizedValueByKey(groupBoxConfigLaunchMode.Name);
			radioButtonLaunchWindowScreen.Text = snapshot.GetLocalizedValueByKey(radioButtonLaunchWindowScreen.Name);
			radioButtonLaunchFullScreen.Text = snapshot.GetLocalizedValueByKey(radioButtonLaunchFullScreen.Name);
			checkBoxVideo.Text = snapshot.GetLocalizedValueByKey(checkBoxVideo.Name);
			checkBoxBorderless.Text = snapshot.GetLocalizedValueByKey(checkBoxBorderless.Name);
			checkBoxBorderless.Text = snapshot.GetLocalizedValueByKey(checkBoxBorderless.Name);

			toolStripAppItem.Text = snapshot.GetLocalizedValueByKey(toolStripAppItem.Name);
			gameSetupSettingsToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(gameSetupSettingsToolStripMenuItem.Name);
			applicationSettingsToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(applicationSettingsToolStripMenuItem.Name);
			applicationHomeFolderToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(applicationHomeFolderToolStripMenuItem.Name);
			exitFromApplicationToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(exitFromApplicationToolStripMenuItem.Name);

			toolStripHelpItem.Text = snapshot.GetLocalizedValueByKey(toolStripHelpItem.Name);
			aboutProgramToolStripMenuItem.Text = snapshot.GetLocalizedValueByKey(aboutProgramToolStripMenuItem.Name);
		}


		private void exitFromApplicationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			const string MESSAGE_CAPTION = "Exit from the Application";
			const string MESSAGE_TEXT = "Do you want to exit from the program ?";
			MessageBoxButtons exit_dialog_buttons = MessageBoxButtons.OKCancel;
			MessageBoxIcon exit_dialog_icon = MessageBoxIcon.Question;

			DialogResult exitDialogResult = MessageBox.Show(
				MESSAGE_TEXT, MESSAGE_CAPTION, exit_dialog_buttons, exit_dialog_icon);

			if (exitDialogResult == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void applicationHomeFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string appWorkDirectory = Directory.GetCurrentDirectory();
			SystemToolbox.ShowFileSystemDirectory(appWorkDirectory);
		}

		private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var appSettingsForm = new AppSettingsForm(this);
			appSettingsForm.Show();
		}

		private void gameSetupSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var gameSetupConfigForm = new GameSetupConfigForm(this);

			Enabled = false;
			Visible = false;

			gameSetupConfigForm.Show();
		}

		private void configSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var modConfigSettingsForm = new ModConfigSettingsForm();
			modConfigSettingsForm.Show();
		}

		private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var aboutProjectForm = new AboutProjectForm();
			aboutProjectForm.Show();
		}


		// QUICK CONFIGURING VIA PROFILES

		private void radioButtonConfigProfile_Gaming_CheckedChanged(object sender, EventArgs e)
		{
			radioButtonLaunchWindowScreen.Checked = false;
			radioButtonLaunchFullScreen.Checked = true;
			checkBoxVideo.Checked = true;
			checkBoxBorderless.Checked = false;

			radioButtonLogOnlyError.Checked = true;
			radioButtonLogOnlyTrace.Checked = false;
			radioButtonLogErrorAndTrace.Checked = false;
		}

		private void radioButtonConfigProfile_Modding_CheckedChanged(object sender, EventArgs e)
		{
			radioButtonLaunchWindowScreen.Checked = true;
			radioButtonLaunchFullScreen.Checked = false;
			checkBoxVideo.Checked = false;
			checkBoxBorderless.Checked = false;

			radioButtonLogOnlyError.Checked = false;
			radioButtonLogOnlyTrace.Checked = false;
			radioButtonLogErrorAndTrace.Checked = true;
		}



		// LAUNCHER PROVIDERS TO RUN THE SELECTED MODIFICATION

		private void radioButtonLauncherProvider_M2TWEOP_CheckedChanged(object sender, EventArgs e)
		{
			DisableLauncherSettingsControls();
		}

		private void radioButtonLauncherProvider_NativeSetup_CheckedChanged(object sender, EventArgs e)
		{
			DisableLauncherSettingsControls();
		}

		private void radioButtonLauncherProvider_BatchScript_CheckedChanged(object sender, EventArgs e)
		{
			DisableLauncherSettingsControls();
		}

		private void radioButtonLauncherProvider_TWEMP_CheckedChanged(object sender, EventArgs e)
		{
			EnableLauncherSettingsControls();
		}

		private void DisableLauncherSettingsControls()
		{
			groupBoxConfigProfiles.Enabled = false;
			groupBoxConfigLaunchMode.Enabled = false;
			groupBoxConfigLogMode.Enabled = false;
			groupBoxConfigCleanerMode.Enabled = false;
		}

		private void EnableLauncherSettingsControls()
		{
			groupBoxConfigProfiles.Enabled = true;
			groupBoxConfigLaunchMode.Enabled = true;
			groupBoxConfigLogMode.Enabled = true;
			groupBoxConfigCleanerMode.Enabled = true;
		}
	}
}
