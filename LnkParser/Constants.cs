using System;

namespace LnkParser
{
    namespace Constants
    {       
        [Flags]
        public enum LinkFlags: int {
            /// <summary>The shell link is saved with an item ID list (IDList).</summary>
            HasLinkTargetIDList =			0x00000001,

            /// <summary>The shell link is saved with link information.</summary>
            HasLinkInfo =					0x00000002,

            /// <summary>The shell link is saved with a name string.</summary>
            HasName =						0x00000004,

            /// <summary>The shell link is saved with a relative path string.</summary>
            HasRelativePath =				0x00000008,

            /// <summary>The shell link is saved with a working directory string.</summary>
            HasWorkingDir =				    0x00000010,

            /// <summary>The shell link is saved with command line arguments.</summary>
            HasArguments =				    0x00000020,

            /// <summary>The shell link is saved with an icon location string.</summary>
            HasIconLocation =				0x00000040,

            /// <summary>The shell link contains Unicode encoded strings. This bit SHOULD be set.</summary>
            IsUnicode =					    0x00000080,

            /// <summary>The LinkInfo structure is ignored.</summary>
            ForceNoLinkInfo =				0x00000100,

            /// <summary>The shell link is saved with an EnvironmentVariableDataBlock.</summary>
            HasExpString =				    0x00000200,

            /// <summary>The target is run in a separate virtual machine when launching a link target that is a 16-bit application.</summary>
            RunInSeparateProcess =		    0x00000400,

            /// <summary>Unused</summary>
            Unused1 =						0x00000800,

            /// <summary>The shell link is saved with a DarwinDataBlock.</summary>
            HasDarwinID =					0x00001000,

            /// <summary>The application is run as a different user when the target of the shell link is activated.</summary>
            RunAsUser =					    0x00002000,

            /// <summary>The shell link is saved with an IconEnvironmentDataBlock.</summary>
            HasExpIcon =					0x00004000,

            /// <summary>The file system location is represented in the shell namespace when the path to an item is parsed into an IDList.</summary>
            NoPidlAlias =					0x00008000,

            /// <summary>Unused</summary>
            Unused2 =						0x00010000,

            /// <summary>The shell link is saved with a ShimDataBlock.</summary>
            RunWithShimLayer =			    0x00020000,

            /// <summary>The TrackerDataBlock is ignored.</summary>
            ForceNoLinkTrack =			    0x00040000,

            /// <summary>The shell link attempts to collect target properties and store them in the PropertyStoreDataBlock when the link target is set.</summary>
            EnableTargetMetadata =		    0x00080000,

            /// <summary>The EnvironmentVariableDataBlock is ignored.</summary>
            DisableLinkPathTracking =		0x00100000,

            /// <summary>The SpecialFolderDataBlock and the KnownFolderDataBlock are ignored when loading the shell link.</summary>
            DisableKnownFolderTracking =	0x00200000,

            /// <summary>If the link has a KnownFolderDataBlock (section 2.5.6), the unaliased form of the known folder IDList SHOULD be used when translating the target IDList at the time that the link is loaded.</summary>
            DisableKnownFolderAlias =		0x00400000,

            /// <summary>Creating a link that references another link is enabled. Otherwise, specifying a link as the target IDList SHOULD NOT be allowed.</summary>
            AllowLinkToLink =				0x00800000,

            /// <summary>When saving a link for which the target IDList is under a known folder, either the unaliased form of that known folder or the target IDList SHOULD be used.</summary>
            UnaliasOnSave =				    0x01000000,

            /// <summary>The target IDList SHOULD NOT be stored; instead, the path specified in the EnvironmentVariableDataBlock SHOULD be used to refer to the target.</summary>
            PreferEnvironmentPath =		    0x02000000,

            /// <summary>When the target is a UNC name that refers to a location on a local machine, the local path IDList in the PropertyStoreDataBlock SHOULD be stored, so it can be used when the link is loaded on the local machine.</summary>
            KeepLocalIDListForUNCTarget =	0x04000000,
        }
        
        public enum ExtraDataSignature: uint 
        {
            EnvironmentProps =			0xa0000001,
            ConsoleProps =				0xa0000002,
            TrackerProps =				0xa0000003,
            ConsoleFeProps =			0xa0000004,
            SpecialFolderProps =		0xa0000005,
            DarwinProps =				0xa0000006,
            IconEnvironmentProps =		0xa0000007,
            ShimProps =					0xa0000008,
            PropertyStoreProps =		0xa0000009,
            KnownFolderProps =			0xa000000b,
            VistaAndAboveIdlistProps =	0xa000000c,
        }

        [Flags]
        public enum FileAttributes: int
        {
            ReadOnly =          0x0001,
            Hidden =            0x0002,
            System =            0x0004,
            Reserved1 =         0x0008,
            Directory =         0x0010,
            Archive =           0x0020,
            Reserved2 =         0x0040,
            Normal =            0x0080,
            Temporary =         0x0100,
            SparseFile =        0x0200,
            ReparsePoint =      0x0400,
            Compressed =        0x0800,
            Offline =           0x1000,
            NotContentIndexed = 0x2000,
            Encrypted =         0x4000,
        }
        
        [Flags]
        public enum LinkInfoFlags: int {
            /// <summary>
            /// If set, the VolumeID and LocalBasePath fields are present, and their locations are specified by the values of the VolumeIDOffset and LocalBasePathOffset fields, respectively.
            /// If the value of the LinkInfoHeaderSize field is greater than or equal to 0x00000024, the LocalBasePathUnicode field is present, and its location is specified by the value of the LocalBasePathOffsetUnicode field.
            /// If not set, the VolumeID, LocalBasePath, and LocalBasePathUnicode fields are not present, and the values of the VolumeIDOffset and LocalBasePathOffset fields are zero.
            /// If the value of the LinkInfoHeaderSize field is greater than or equal to 0x00000024, the value of the LocalBasePathOffsetUnicode field is zero.
            /// </summary>
            VolumeIDAndLocalBasePath =               0x00000001	

            /// <summary>
            /// If set, the CommonNetworkRelativeLink field is present, and its location is specified by the value of the CommonNetworkRelativeLinkOffset field. 
            /// If not set, the CommonNetworkRelativeLink field is not present, and the value of the CommonNetworkRelativeLinkOffset field is zero.
            /// </summary>
            CommonNetworkRelativeLinkAndPathSuffix = 0x00000002
        }

        /// <summary>
        /// Enumeration for virtual keys.
        /// </summary>
        [Flags]
        public enum VirtualKeys
            : ushort
        {
            /// <summary></summary>
            LeftButton = 0x01,
            /// <summary></summary>
            RightButton = 0x02,
            /// <summary></summary>
            Cancel = 0x03,
            /// <summary></summary>
            MiddleButton = 0x04,
            /// <summary></summary>
            ExtraButton1 = 0x05,
            /// <summary></summary>
            ExtraButton2 = 0x06,
            /// <summary></summary>
            Back = 0x08,
            /// <summary></summary>
            Tab = 0x09,
            /// <summary></summary>
            Clear = 0x0C,
            /// <summary></summary>
            Return = 0x0D,
            /// <summary></summary>
            Shift = 0x10,
            /// <summary></summary>
            Control = 0x11,
            /// <summary></summary>
            Menu = 0x12,
            /// <summary></summary>
            Pause = 0x13,
            /// <summary></summary>
            CapsLock = 0x14,
            /// <summary></summary>
            Kana = 0x15,
            /// <summary></summary>
            Hangeul = 0x15,
            /// <summary></summary>
            Hangul = 0x15,
            /// <summary></summary>
            Junja = 0x17,
            /// <summary></summary>
            Final = 0x18,
            /// <summary></summary>
            Hanja = 0x19,
            /// <summary></summary>
            Kanji = 0x19,
            /// <summary></summary>
            Escape = 0x1B,
            /// <summary></summary>
            Convert = 0x1C,
            /// <summary></summary>
            NonConvert = 0x1D,
            /// <summary></summary>
            Accept = 0x1E,
            /// <summary></summary>
            ModeChange = 0x1F,
            /// <summary></summary>
            Space = 0x20,
            /// <summary></summary>
            Prior = 0x21,
            /// <summary></summary>
            Next = 0x22,
            /// <summary></summary>
            End = 0x23,
            /// <summary></summary>
            Home = 0x24,
            /// <summary></summary>
            Left = 0x25,
            /// <summary></summary>
            Up = 0x26,
            /// <summary></summary>
            Right = 0x27,
            /// <summary></summary>
            Down = 0x28,
            /// <summary></summary>
            Select = 0x29,
            /// <summary></summary>
            Print = 0x2A,
            /// <summary></summary>
            Execute = 0x2B,
            /// <summary></summary>
            Snapshot = 0x2C,
            /// <summary></summary>
            Insert = 0x2D,
            /// <summary></summary>
            Delete = 0x2E,
            /// <summary></summary>
            Help = 0x2F,
            /// <summary></summary>
            N0 = 0x30,
            /// <summary></summary>
            N1 = 0x31,
            /// <summary></summary>
            N2 = 0x32,
            /// <summary></summary>
            N3 = 0x33,
            /// <summary></summary>
            N4 = 0x34,
            /// <summary></summary>
            N5 = 0x35,
            /// <summary></summary>
            N6 = 0x36,
            /// <summary></summary>
            N7 = 0x37,
            /// <summary></summary>
            N8 = 0x38,
            /// <summary></summary>
            N9 = 0x39,
            /// <summary></summary>
            A = 0x41,
            /// <summary></summary>
            B = 0x42,
            /// <summary></summary>
            C = 0x43,
            /// <summary></summary>
            D = 0x44,
            /// <summary></summary>
            E = 0x45,
            /// <summary></summary>
            F = 0x46,
            /// <summary></summary>
            G = 0x47,
            /// <summary></summary>
            H = 0x48,
            /// <summary></summary>
            I = 0x49,
            /// <summary></summary>
            J = 0x4A,
            /// <summary></summary>
            K = 0x4B,
            /// <summary></summary>
            L = 0x4C,
            /// <summary></summary>
            M = 0x4D,
            /// <summary></summary>
            N = 0x4E,
            /// <summary></summary>
            O = 0x4F,
            /// <summary></summary>
            P = 0x50,
            /// <summary></summary>
            Q = 0x51,
            /// <summary></summary>
            R = 0x52,
            /// <summary></summary>
            S = 0x53,
            /// <summary></summary>
            T = 0x54,
            /// <summary></summary>
            U = 0x55,
            /// <summary></summary>
            V = 0x56,
            /// <summary></summary>
            W = 0x57,
            /// <summary></summary>
            X = 0x58,
            /// <summary></summary>
            Y = 0x59,
            /// <summary></summary>
            Z = 0x5A,
            /// <summary></summary>
            LeftWindows = 0x5B,
            /// <summary></summary>
            RightWindows = 0x5C,
            /// <summary></summary>
            Application = 0x5D,
            /// <summary></summary>
            Sleep = 0x5F,
            /// <summary></summary>
            Numpad0 = 0x60,
            /// <summary></summary>
            Numpad1 = 0x61,
            /// <summary></summary>
            Numpad2 = 0x62,
            /// <summary></summary>
            Numpad3 = 0x63,
            /// <summary></summary>
            Numpad4 = 0x64,
            /// <summary></summary>
            Numpad5 = 0x65,
            /// <summary></summary>
            Numpad6 = 0x66,
            /// <summary></summary>
            Numpad7 = 0x67,
            /// <summary></summary>
            Numpad8 = 0x68,
            /// <summary></summary>
            Numpad9 = 0x69,
            /// <summary></summary>
            Multiply = 0x6A,
            /// <summary></summary>
            Add = 0x6B,
            /// <summary></summary>
            Separator = 0x6C,
            /// <summary></summary>
            Subtract = 0x6D,
            /// <summary></summary>
            Decimal = 0x6E,
            /// <summary></summary>
            Divide = 0x6F,
            /// <summary></summary>
            F1 = 0x70,
            /// <summary></summary>
            F2 = 0x71,
            /// <summary></summary>
            F3 = 0x72,
            /// <summary></summary>
            F4 = 0x73,
            /// <summary></summary>
            F5 = 0x74,
            /// <summary></summary>
            F6 = 0x75,
            /// <summary></summary>
            F7 = 0x76,
            /// <summary></summary>
            F8 = 0x77,
            /// <summary></summary>
            F9 = 0x78,
            /// <summary></summary>
            F10 = 0x79,
            /// <summary></summary>
            F11 = 0x7A,
            /// <summary></summary>
            F12 = 0x7B,
            /// <summary></summary>
            F13 = 0x7C,
            /// <summary></summary>
            F14 = 0x7D,
            /// <summary></summary>
            F15 = 0x7E,
            /// <summary></summary>
            F16 = 0x7F,
            /// <summary></summary>
            F17 = 0x80,
            /// <summary></summary>
            F18 = 0x81,
            /// <summary></summary>
            F19 = 0x82,
            /// <summary></summary>
            F20 = 0x83,
            /// <summary></summary>
            F21 = 0x84,
            /// <summary></summary>
            F22 = 0x85,
            /// <summary></summary>
            F23 = 0x86,
            /// <summary></summary>
            F24 = 0x87,
            /// <summary></summary>
            NumLock = 0x90,
            /// <summary></summary>
            ScrollLock = 0x91,
            /// <summary></summary>
            NEC_Equal = 0x92,
            /// <summary></summary>
            Fujitsu_Jisho = 0x92,
            /// <summary></summary>
            Fujitsu_Masshou = 0x93,
            /// <summary></summary>
            Fujitsu_Touroku = 0x94,
            /// <summary></summary>
            Fujitsu_Loya = 0x95,
            /// <summary></summary>
            Fujitsu_Roya = 0x96,
            /// <summary></summary>
            LeftShift = 0xA0,
            /// <summary></summary>
            RightShift = 0xA1,
            /// <summary></summary>
            LeftControl = 0xA2,
            /// <summary></summary>
            RightControl = 0xA3,
            /// <summary></summary>
            LeftMenu = 0xA4,
            /// <summary></summary>
            RightMenu = 0xA5,
            /// <summary></summary>
            BrowserBack = 0xA6,
            /// <summary></summary>
            BrowserForward = 0xA7,
            /// <summary></summary>
            BrowserRefresh = 0xA8,
            /// <summary></summary>
            BrowserStop = 0xA9,
            /// <summary></summary>
            BrowserSearch = 0xAA,
            /// <summary></summary>
            BrowserFavorites = 0xAB,
            /// <summary></summary>
            BrowserHome = 0xAC,
            /// <summary></summary>
            VolumeMute = 0xAD,
            /// <summary></summary>
            VolumeDown = 0xAE,
            /// <summary></summary>
            VolumeUp = 0xAF,
            /// <summary></summary>
            MediaNextTrack = 0xB0,
            /// <summary></summary>
            MediaPrevTrack = 0xB1,
            /// <summary></summary>
            MediaStop = 0xB2,
            /// <summary></summary>
            MediaPlayPause = 0xB3,
            /// <summary></summary>
            LaunchMail = 0xB4,
            /// <summary></summary>
            LaunchMediaSelect = 0xB5,
            /// <summary></summary>
            LaunchApplication1 = 0xB6,
            /// <summary></summary>
            LaunchApplication2 = 0xB7,
            /// <summary></summary>
            OEM1 = 0xBA,
            /// <summary></summary>
            OEMPlus = 0xBB,
            /// <summary></summary>
            OEMComma = 0xBC,
            /// <summary></summary>
            OEMMinus = 0xBD,
            /// <summary></summary>
            OEMPeriod = 0xBE,
            /// <summary></summary>
            OEM2 = 0xBF,
            /// <summary></summary>
            OEM3 = 0xC0,
            /// <summary></summary>
            OEM4 = 0xDB,
            /// <summary></summary>
            OEM5 = 0xDC,
            /// <summary></summary>
            OEM6 = 0xDD,
            /// <summary></summary>
            OEM7 = 0xDE,
            /// <summary></summary>
            OEM8 = 0xDF,
            /// <summary></summary>
            OEMAX = 0xE1,
            /// <summary></summary>
            OEM102 = 0xE2,
            /// <summary></summary>
            ICOHelp = 0xE3,
            /// <summary></summary>
            ICO00 = 0xE4,
            /// <summary></summary>
            ProcessKey = 0xE5,
            /// <summary></summary>
            ICOClear = 0xE6,
            /// <summary></summary>
            Packet = 0xE7,
            /// <summary></summary>
            OEMReset = 0xE9,
            /// <summary></summary>
            OEMJump = 0xEA,
            /// <summary></summary>
            OEMPA1 = 0xEB,
            /// <summary></summary>
            OEMPA2 = 0xEC,
            /// <summary></summary>
            OEMPA3 = 0xED,
            /// <summary></summary>
            OEMWSCtrl = 0xEE,
            /// <summary></summary>
            OEMCUSel = 0xEF,
            /// <summary></summary>
            OEMATTN = 0xF0,
            /// <summary></summary>
            OEMFinish = 0xF1,
            /// <summary></summary>
            OEMCopy = 0xF2,
            /// <summary></summary>
            OEMAuto = 0xF3,
            /// <summary></summary>
            OEMENLW = 0xF4,
            /// <summary></summary>
            OEMBackTab = 0xF5,
            /// <summary></summary>
            ATTN = 0xF6,
            /// <summary></summary>
            CRSel = 0xF7,
            /// <summary></summary>
            EXSel = 0xF8,
            /// <summary></summary>
            EREOF = 0xF9,
            /// <summary></summary>
            Play = 0xFA,
            /// <summary></summary>
            Zoom = 0xFB,
            /// <summary></summary>
            Noname = 0xFC,
            /// <summary></summary>
            PA1 = 0xFD,
            /// <summary></summary>
            OEMClear = 0xFE,

            HOTKEYF_SHIFT = 1,
            HOTKEYF_CONTROL = 2,
            HOTKEYF_ALT = 4
        }
        
        public static class KnownFolderId {
            public readonly Guid AddNewPrograms =  			new Guid("71d961debc5e024fa3a96c82895e5c04");
            public readonly Guid AdminTools =  				new Guid("70f14e722da4ef4f9f26b60e846fba4f");
            public readonly Guid AppDataLow =  				new Guid("a4a120a58017f64fbd18167343c5af16");
            public readonly Guid ApplicationShortcuts =  	new Guid("818791A3F2e59048B3D9A7E54332328C");
            public readonly Guid AppsFolder =  				new Guid("8d50871ec289f0428a7e645a0f50ca58");
            public readonly Guid AppUpdates =  				new Guid("99ce05a327f52b498b1a7e76fa98d6e4");
            public readonly Guid CDBurning =  				new Guid("10ab529e0df8df49acb84330f5687855");
            public readonly Guid ChangeRemovePrograms =  	new Guid("ac6672df749267488d553bd661de872d");
            public readonly Guid CommonAdminTools =  		new Guid("7d4e38d0c3ba97478f14cba229b392b5");
            public readonly Guid CommonOEMLinks =  			new Guid("d0e2bac1df103443bedd7aa20b227a9d");
            public readonly Guid CommonPrograms =  			new Guid("4ed43901fe6af24986903dafcae6ffb8");
            public readonly Guid CommonStartMenu =  		new Guid("195711a42ed61d49aa7ce74b8be3b067");
            public readonly Guid CommonStartup =  			new Guid("35eaa582cdd9c5479629e15d2f714e6e");
            public readonly Guid CommonTemplates =  		new Guid("e73742b9ac5747439151b08c6c32d1f7");
            public readonly Guid ComputerFolder =  			new Guid("7c83c00af8bb2a45850d79d08e667ca7");
            public readonly Guid ConflictFolder =  			new Guid("45fbfe4b7d340640a5beac0cb0567192");
            public readonly Guid ConnectionsFolder =  		new Guid("2bd90c6f972ed14588ffb0d186b8dedd");
            public readonly Guid Contacts =  				new Guid("54487856cbc62b46816988e350acb882");
            public readonly Guid ControlPanelFolder =  		new Guid("eb4aa782b4ae5c46a014d097ee346d63");
            public readonly Guid Cookies =  				new Guid("5d760f2be9c07141908e08a611b84ff6");
            public readonly Guid Desktop =  				new Guid("3accbfb42cdb4c42b0297fe99a87c641");
            public readonly Guid DeviceMetadataStore =  	new Guid("e9a5e45CEBe49D47B89F130C02886155");
            public readonly Guid Documents =  				new Guid("d09ad3fd8f23af46adb46c85480369c7");
            public readonly Guid DocumentsLibrary =  		new Guid("7db10d7BD29c934a973346CC89022E7C");
            public readonly Guid Downloads =  				new Guid("90e24d373f126545916439c4925e467b");
            public readonly Guid Favorites =  				new Guid("61f77717ad688a4d87bd30b759fa33dd");
            public readonly Guid Fonts =  					new Guid("b78c22fd11aee34a864c16f3910ab8fe");
            public readonly Guid Games =  					new Guid("1a2cc5ca3db5dc4e92d76b2e8ac19434");
            public readonly Guid GameTasks =  				new Guid("61ae4f05d84d874780b6090220c4b700");
            public readonly Guid History =  				new Guid("3b8adcd984b72e43a7815a1130a75963");
            public readonly Guid HomeGroup =  				new Guid("6b8a5252E3b9DD4aB60D588C2DBA842D");
            public readonly Guid HomeGroupCurrentUser =  	new Guid("a3b6749BFD0d114f9E785F7800F2E772");
            public readonly Guid ImplicitAppShortcuts =  	new Guid("6f25b5BCF679EE4cB725DC34E402FD46");
            public readonly Guid InternetCache =  			new Guid("e8812435be335142ba856007caedcf9d");
            public readonly Guid InternetFolder =  			new Guid("74789f4d0c4e0449967b40b0d20c3e4b");
            public readonly Guid Libraries =  				new Guid("dca53e1B87b58647B4EFBD1DC332AEAE");
            public readonly Guid Links =  					new Guid("e0d5b9bfa9c64c40b2b2ae6db6af4968");
            public readonly Guid LocalAppData =  			new Guid("8527b3f1ba6fcf4f9d557b8e7f157091");
            public readonly Guid LocalAppDataLow =  		new Guid("a4a120A58017F64fBD18167343C5AF16");
            public readonly Guid LocalizedResourcesDir =  	new Guid("5e37002a4c22de49b8d1440df7ef3ddc");
            public readonly Guid Music =  					new Guid("71d5d84b196dd348be97422220080e43");
            public readonly Guid MusicLibrary =  			new Guid("0aab12216Ac8FE4fA3680DE96E47012E");
            public readonly Guid NetHood =  				new Guid("53bfabc57fe12141890086626fc2c973");
            public readonly Guid NetworkFolder =  			new Guid("c4ee0bd2a85c0549ae3bbf251ea09b53");
            public readonly Guid OriginalImages =  			new Guid("aac0362c1258874bbfd04cd0dfb19b39");
            public readonly Guid PhotoAlbums =  			new Guid("90cfd26933fcb74f9a0cebb0f0fcb43c");
            public readonly Guid Pictures =  				new Guid("3081e2331e4e7646835a98395c3bc3bb");
            public readonly Guid PicturesLibrary =  		new Guid("9fae90A93Ba0804e94BC9912D7504104");
            public readonly Guid Playlists =  				new Guid("c7c192de7f83694fa3bb86e631204a23");
            public readonly Guid PrintersFolder =  			new Guid("2d4efc76add61945a66337bd56068185");
            public readonly Guid PrintHood =  				new Guid("8dbd7492d1cfc341b35eb13f55a758f4");
            public readonly Guid Profile =  				new Guid("8f856c5e220e60479afeea3317b67173");
            public readonly Guid ProgramData =  			new Guid("825dab62c1fdc34da9dd070d1d495d97");
            public readonly Guid ProgramFiles =  			new Guid("b6635e90bfc14e49b29c65b732d3d21a");
            public readonly Guid ProgramFilesCommon =  		new Guid("05edf1f76d9fa247aaae29d317c6f066");
            public readonly Guid ProgramFilesCommonX64 =  	new Guid("a7d565630d0fe54587f60da56b6a4f7d");
            public readonly Guid ProgramFilesCommonX86 =  	new Guid("244d97dec6d93e4dbf91f4455120b917");
            public readonly Guid ProgramFilesX64 =  		new Guid("7793806df06a4b448957a3773f02200e");
            public readonly Guid ProgramFilesX86 =  		new Guid("ef405a7cfba0fc4b874ac0f2e0b9fa8e");
            public readonly Guid Programs =  				new Guid("775d7fa72b2ec344a6a2aba601054a51");
            public readonly Guid Public =  					new Guid("a276dfdf2ac8634d906a5644ac457385");
            public readonly Guid PublicDesktop =  			new Guid("0d34aac40ff26348afeff87ef2e6ba25");
            public readonly Guid PublicDocuments =  		new Guid("af2448ede4dca84581e2fc7965083634");
            public readonly Guid PublicDownloads =  		new Guid("9b4c643db81f304f9b45f670235f79c0");
            public readonly Guid PublicGameTasks =  		new Guid("3625bfdea8e1594cb6a2414586476aea");
            public readonly Guid PublicLibraries =  		new Guid("0bf8da48CFe64E4fB8000E69D84EE384");
            public readonly Guid PublicMusic =  			new Guid("b5fa143257979842bb6192a9deaa44ff");
            public readonly Guid PublicPictures =  			new Guid("86fbebb607693c419af74fc2abf07cc5");
            public readonly Guid PublicRingtones =  		new Guid("60ab55E53B15174d9F04A5FE99FC15EC");
            public readonly Guid PublicUserTiles =  		new Guid("6caf8204f108344c8c90e17ec98b1e17");
            public readonly Guid PublicVideos =  			new Guid("3a1800248561fb49a2d84a392a602ba3");
            public readonly Guid QuickLaunch =  			new Guid("21f0a452757ba9489f6b4b87a210bc8f");
            public readonly Guid Recent =  					new Guid("81c050aed2eb8a4386558a092e34987a");
            public readonly Guid RecordedTV =  				new Guid("01e085bd2e111e43983b7b15ac09fff1");
            public readonly Guid RecordedTVLibrary =  		new Guid("a2db6f1A2Df45843A798B74D745926C5");
            public readonly Guid RecycleBin =  				new Guid("464053b7cb3e184cbe4e64cd4cb7d6ac");
            public readonly Guid ResourceDir =  			new Guid("310cd18adb2a9642a8f7e4701232c972");
            public readonly Guid Ringtones =  				new Guid("4b0470C89Ef42641A9C3B52A1FF411E8");
            public readonly Guid RoamingAppData =  			new Guid("db85b63ef965f64ca03ae3ef65729f3d");
            public readonly Guid RoamingTiles =  			new Guid("5afcbc0094ed484e96A13F6217F21990");
            public readonly Guid SampleMusic =  			new Guid("68c650b27df5e14ea63c290ee7d1aa1f");
            public readonly Guid SamplePictures =  			new Guid("400590c47923754c844b64e6faf8716b");
            public readonly Guid SamplePlaylists =  		new Guid("b369ca15ee30c149ace16b5ec372afb5");
            public readonly Guid SampleVideos =  			new Guid("94ad9e85852ead48a71a0969cb56a6cd");
            public readonly Guid SavedGames =  				new Guid("ff325c4c9dbbb043b5b42d72e54eaaa4");
            public readonly Guid SavedSearches =  			new Guid("043a1d7dbbde154195cf2f29da2920da");
            public readonly Guid SEARCH_CSC =  				new Guid("46e432eeca31ba4a814fa5ebd2fd6d5e");
            public readonly Guid SEARCH_MAPI =  			new Guid("180eec989820444d864466979315a281");
            public readonly Guid SearchHome =  				new Guid("d1370319cab82141a6396d472d16972a");
            public readonly Guid SendTo =  					new Guid("6c038389c0274b408f08102d10dcfd74");
            public readonly Guid SidebarDefaultParts =  	new Guid("546e397bc59e0043be0a2482ebae1a26");
            public readonly Guid SidebarParts =  			new Guid("2e365da7fc50b74fac2ca8beaa314493");
            public readonly Guid StartMenu =  				new Guid("c3535b6248abc14eba1fa1ef4146fc19");
            public readonly Guid Startup =  				new Guid("bb207db96af4974cba105e3608430854");
            public readonly Guid SyncManagerFolder =  		new Guid("f88b66434ec1b24997c9747784d784b7");
            public readonly Guid SyncResults =  			new Guid("439a9a2844be5740a41b587a76d7e7f9");
            public readonly Guid SyncSetupFolder =  		new Guid("3841210fd3b1904abba927cbc0c5389a");
            public readonly Guid System =  					new Guid("774ec11ae7025d4eb7442eb1ae5198b7");
            public readonly Guid SystemX86 =  				new Guid("b03152d6f1b25748a4cea8e7c6ea7d27");
            public readonly Guid Templates =  				new Guid("e89332a64e66db48a079df759e0509f7");
            public readonly Guid TreeProperties =  			new Guid("ad49375b9fb4c14983eb15370fbd4882");
            public readonly Guid UserPinned =  				new Guid("ab95399E9C1f134fB82748B24B6C7174");
            public readonly Guid UserProfiles =  			new Guid("72d262070ac5b04ba382697dcd729b80");
            public readonly Guid UserProgramFiles =  		new Guid("e2aed75C1922674aB85D6C9CE15660CB");
            public readonly Guid UserProgramFilesCommon =  	new Guid("5730bdBC5Cca2246B42DBC56DB0AE516");
            public readonly Guid UsersFiles =  				new Guid("7c0fcef30149cc4a8648d5d44b04ef8f");
            public readonly Guid UsersLibraries =  			new Guid("25481e03947bc34db131e946b44c8dd5");
            public readonly Guid UsersLibrariesFolder =  	new Guid("5d5402A3FFde4b46ABE861C8648D939B");
            public readonly Guid UserTiles =  				new Guid("b1a08c00b455564cb8a84de4b299d3be");
            public readonly Guid Videos =  					new Guid("1d9b9818b5995b45841cab7c74e4ddfc");
            public readonly Guid VideosLibrary =  			new Guid("2f921e494356F44aA7EB4E7A138D8174");
            public readonly Guid Windows =  				new Guid("04f48bf3431df242930567de0b28fc23");

            // Additional IDs found on the net and in the registry.
            public readonly Guid CD_Burner =  				new Guid("058aebfbeebe4244804e409d6c4515e9");
            public readonly Guid Control_Panel =  			new Guid("94e69953e56c6c4d8fce1d8870fdcba0");	// Control Panel command object.
            public readonly Guid Control_Panel2 =  			new Guid("2020ec21ea3a6910a2dd08002b30309d");
            public readonly Guid CSC_Folder =  				new Guid("7b2e7abdcb21b241a086b309680c6b7e");
            public readonly Guid Internet_Explorer =  		new Guid("80531c87a0426910a2ea08002b30309d");
            public readonly Guid My_Computer =  			new Guid("e04fd020ea3a6910a2d808002b30309d");
            public readonly Guid My_Documents =  			new Guid("ba8f0d4525add01198a80800361b1103");
            public readonly Guid My_Games =  				new Guid("df8f22eda89e704883b196b02cfe0d52");
            public readonly Guid My_Network_Places =  		new Guid("602c8d20ea3a6910a2d708002b30309d");
            public readonly Guid Network_Connections =  	new Guid("c7ac07700232d111aad200805fc1270e");
            public readonly Guid Printers_and_Faxes =  		new Guid("80a22722ea3a6910a2de08002b30309d");
            public readonly Guid Dial_up_Connection =  		new Guid("d76a12ba6621d111b1d000805fc1270e");
            public readonly Guid Users =  					new Guid("471a0359723fa74489c55595fe6b30ee");	// Same as UsersFiles?
            public readonly Guid Show_Desktop =  			new Guid("0df98030add7d911bd980000947b0257");
            public readonly Guid Window_Switcher =  		new Guid("0ef98030add7d911bd980000947b0257");
            public readonly Guid Search =  					new Guid("f0a15925d721d411bdaf00c04f60b9f0");
            public readonly Guid Help_and_Support =  		new Guid("f1a15925d721d411bdaf00c04f60b9f0");
            public readonly Guid Windows_Security =  		new Guid("f2a15925d721d411bdaf00c04f60b9f0");
            public readonly Guid Run =  					new Guid("f3a15925d721d411bdaf00c04f60b9f0");
            public readonly Guid Email =  					new Guid("f5a15925d721d411bdaf00c04f60b9f0");
            public readonly Guid Set_Program_Access =  		new Guid("f7a15925d721d411bdaf00c04f60b9f0");
            public readonly Guid Start_Menu_Provider =  	new Guid("1353f9da4de4af46be1bcbacea2c3065");
            public readonly Guid Search_Results =  			new Guid("1e1ade7f318ba54993b86be14cfa4943");
            public readonly Guid Start_Menu =  				new Guid("cbb487efcef2854786584ca6c63e38c6");

            public readonly Guid Unknown =  				new Guid("ffffffffffffffffffffffffffffffff");
        }
    }
}
