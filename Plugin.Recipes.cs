
using System.Collections.Generic;

namespace Better914
{
	partial class Plugin
	{
		public static List<Scp914Recipe> CreateDefaultList()
		{
			return new List<Scp914Recipe>()
			{
				#region Keycards
				new Scp914Recipe()
				{
					item = ItemType.KeycardJanitor,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Coin }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardZoneManager }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardScientist }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardScientistMajor }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // % VFine
					level_4 = new ItemType[] { ItemType.KeycardFacilityManager, ItemType.KeycardNTFCommander }, // % Vfine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardScientist,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardJanitor }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardZoneManager }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardScientistMajor }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardFacilityManager, ItemType.KeycardNTFCommander }, // % VFine
					level_4 = new ItemType[] { ItemType.KeycardO5 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardScientistMajor,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardJanitor }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardScientist }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardGuard }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardFacilityManager, ItemType.KeycardNTFCommander }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardO5 }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardContainmentEngineer,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardJanitor }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardScientist }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardScientistMajor }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardSeniorGuard }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardFacilityManager, ItemType.KeycardNTFCommander }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardO5 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardFacilityManager,
					level__4 = new ItemType[] { ItemType.KeycardGuard }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardSeniorGuard }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardNTFLieutenant }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardNTFCommander }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardO5 }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardO5,
					level__4 = new ItemType[] { ItemType.KeycardJanitor }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardScientist }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardScientistMajor }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // Coarse
					level_0 = new ItemType[] {  }, // 1:1
					level_1 = new ItemType[] { ItemType.Coin }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardNTFCommander,
					level__4 = new ItemType[] { ItemType.KeycardScientist }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardGuard }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardSeniorGuard }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardNTFLieutenant }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardChaosInsurgency }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardO5 }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardNTFLieutenant,
					level__4 = new ItemType[] { ItemType.KeycardJanitor }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardScientist }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardGuard }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardSeniorGuard }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardNTFCommander }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardO5 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardSeniorGuard,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardJanitor }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardScientist }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardGuard }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardContainmentEngineer }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardNTFLieutenant }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardNTFCommander }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardO5 }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardGuard,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardJanitor }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardScientist }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardScientistMajor }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardSeniorGuard }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardNTFLieutenant }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardNTFCommander }, // % VFine
					level_4 = new ItemType[] { ItemType.KeycardO5 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardZoneManager,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardJanitor }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardScientist }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardGuard }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardNTFLieutenant }, // Fine
					level_2 = new ItemType[] { ItemType.KeycardNTFCommander }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardO5 }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.KeycardChaosInsurgency,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.KeycardJanitor }, // % Rough
					level__2 = new ItemType[] { ItemType.KeycardGuard }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.KeycardNTFLieutenant }, // Coarse
					level_0 = new ItemType[] { ItemType.KeycardNTFCommander }, // 1:1
					level_1 = new ItemType[] { ItemType.KeycardO5 }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				#endregion
				#region Radio
				new Scp914Recipe()
				{
					item = ItemType.Radio,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { ItemType.WeaponManagerTablet }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.WeaponManagerTablet,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Radio }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { ItemType.Disarmer }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.GunUSP }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.Disarmer,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Radio }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.WeaponManagerTablet }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				#endregion
				#region Medical
				new Scp914Recipe()
				{
					item = ItemType.Painkillers,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Coin }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Medkit }, // Fine
					level_2 = new ItemType[] { ItemType.Medkit }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Adrenaline }, // % VFine
					level_4 = new ItemType[] { ItemType.SCP500 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.Medkit,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Painkillers }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Adrenaline }, // Fine
					level_2 = new ItemType[] { ItemType.Adrenaline }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.SCP500 }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.Adrenaline,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Painkillers }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Medkit }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.SCP500, ItemType.SCP207 }, // Fine
					level_2 = new ItemType[] { ItemType.SCP500 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.SCP207,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Medkit }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.SCP500 }, // Fine
					level_2 = new ItemType[] { ItemType.SCP500 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.SCP268 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.SCP500,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Painkillers }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Medkit }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Coin }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.SCP268 }, // % VFine
					level_4 = new ItemType[] { ItemType.SCP268 }, // % VFine
				},
				#endregion
				#region Grenades
				new Scp914Recipe()
				{
					item = ItemType.Flashlight,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Coin }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GrenadeFlash }, // Fine
					level_2 = new ItemType[] { ItemType.GrenadeFlash }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.GrenadeFrag }, // % VFine
					level_4 = new ItemType[] { ItemType.SCP018 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GrenadeFlash,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Flashlight }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GrenadeFrag }, // Fine
					level_2 = new ItemType[] { ItemType.GrenadeFrag }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.SCP018 }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GrenadeFrag,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Flashlight }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GrenadeFlash }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Coin }, // Fine
					level_2 = new ItemType[] { ItemType.SCP018 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.SCP018,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Flashlight }, // % Rough
					level__2 = new ItemType[] { ItemType.GrenadeFlash }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GrenadeFrag }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				#endregion
				#region Ammo
				new Scp914Recipe()
				{
					item = ItemType.Ammo9mm,
					level__4 = new ItemType[] { ItemType.Ammo762 }, // % Rough
					level__3 = new ItemType[] { ItemType.Ammo762 }, // % Rough
					level__2 = new ItemType[] { ItemType.Ammo762 }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Ammo762 }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Ammo556 }, // Fine
					level_2 = new ItemType[] { ItemType.Ammo556 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Ammo556 }, // % VFine
					level_4 = new ItemType[] { ItemType.Ammo556 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.Ammo556,
					level__4 = new ItemType[] { ItemType.Ammo9mm }, // % Rough
					level__3 = new ItemType[] { ItemType.Ammo9mm }, // % Rough
					level__2 = new ItemType[] { ItemType.Ammo9mm }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Ammo9mm }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Ammo762 }, // Fine
					level_2 = new ItemType[] { ItemType.Ammo762 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Ammo762 }, // % VFine
					level_4 = new ItemType[] { ItemType.Ammo762 }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.Ammo762,
					level__4 = new ItemType[] { ItemType.Ammo556 }, // % Rough
					level__3 = new ItemType[] { ItemType.Ammo556 }, // % Rough
					level__2 = new ItemType[] { ItemType.Ammo556 }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Ammo556 }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.Ammo9mm }, // Fine
					level_2 = new ItemType[] { ItemType.Ammo9mm }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Ammo9mm }, // % VFine
					level_4 = new ItemType[] { ItemType.Ammo9mm }, // % VFine
				},
				#endregion
				#region Guns
				new Scp914Recipe()
				{
					item = ItemType.GunCOM15,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Coin }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GunUSP }, // Fine
					level_2 = new ItemType[] { ItemType.GunMP7 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.GunProject90 }, // % VFine
					level_4 = new ItemType[] { ItemType.GunE11SR }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GunUSP,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GunCOM15 }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GunMP7 }, // Fine
					level_2 = new ItemType[] { ItemType.GunProject90 }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.GunE11SR }, // % VFine
					level_4 = new ItemType[] { ItemType.GunLogicer }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GunMP7,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.GunCOM15 }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GunUSP }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GunProject90 }, // Fine
					level_2 = new ItemType[] { ItemType.GunE11SR }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.GunLogicer }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GunProject90,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.GunCOM15 }, // % Rough
					level__2 = new ItemType[] { ItemType.GunUSP }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GunMP7 }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GunE11SR }, // Fine
					level_2 = new ItemType[] { ItemType.GunLogicer }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GunE11SR,
					level__4 = new ItemType[] { ItemType.GunCOM15 }, // % Rough
					level__3 = new ItemType[] { ItemType.GunUSP }, // % Rough
					level__2 = new ItemType[] { ItemType.GunMP7 }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GunProject90 }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { ItemType.GunLogicer }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.GunLogicer,
					level__4 = new ItemType[] { ItemType.GunUSP }, // % Rough
					level__3 = new ItemType[] { ItemType.GunMP7 }, // % Rough
					level__2 = new ItemType[] { ItemType.GunProject90 }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GunE11SR }, // Coarse
					level_0 = new ItemType[] {  }, // 1:1
					level_1 = new ItemType[] { ItemType.Coin }, // Fine
					level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				#endregion
				#region OTHER (Micro + SCP)
				new Scp914Recipe()
				{
					item = ItemType.MicroHID,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.GunCOM15 }, // % Rough
					level__2 = new ItemType[] { ItemType.GunMP7 }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.GunE11SR }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				new Scp914Recipe()
				{
					item = ItemType.SCP268,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.SCP207 }, // % Coarse, Rough
					level__1 = new ItemType[] { }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.Coin }, // % VFine
					level_4 = new ItemType[] { ItemType.Coin }, // % VFine
				},
				#endregion
				#region Coin
				new Scp914Recipe()
				{
					item = ItemType.Coin,
					level__4 = new ItemType[] { ItemType.Coin }, // % Rough
					level__3 = new ItemType[] { ItemType.Coin }, // % Rough
					level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
					level__1 = new ItemType[] { ItemType.Coin }, // Coarse
					level_0 = new ItemType[] { }, // 1:1
					level_1 = new ItemType[] { }, // Fine
					level_2 = new ItemType[] { }, // % Fine, VFine
					level_3 = new ItemType[] { ItemType.KeycardJanitor, ItemType.Radio, ItemType.Painkillers, ItemType.GunCOM15, ItemType.Flashlight }, // % VFine
					level_4 = new ItemType[] { ItemType.KeycardScientist, ItemType.Medkit, ItemType.Ammo9mm }, // % VFine
				},
				#endregion
			};
		}

		public static Scp914Recipe CreateDefaultRecipe(ItemType type)
		{
			return new Scp914Recipe()
			{
				item = type,
				level__4 = new ItemType[] { ItemType.None }, // % Rough
				level__3 = new ItemType[] { ItemType.Coin }, // % Rough
				level__2 = new ItemType[] { ItemType.Coin }, // % Coarse, Rough
				level__1 = new ItemType[] { }, // Coarse
				level_0 = new ItemType[] { }, // 1:1
				level_1 = new ItemType[] { }, // Fine
				level_2 = new ItemType[] { ItemType.Coin }, // % Fine, VFine
				level_3 = new ItemType[] { ItemType.Coin }, // % VFine
				level_4 = new ItemType[] { ItemType.None }, // % VFine
			};
		}
	}
}