using System.Runtime.InteropServices;

/// <summary>
/// winnt.h
/// BUILD Version: 0073
/// </summary>
namespace Win32API.WinNT
{
    /// <summary>
    /// The LUID_AND_ATTRIBUTES structure represents a locally unique identifier (LUID) and its attributes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LUID_AND_ATTRIBUTES
    {
        /// <summary>
        /// Specifies an LUID value.
        /// </summary>
        public long Luid;
        /// <summary>
        /// Specifies attributes of the LUID. This value contains up to 32 one-bit flags. Its meaning is dependent on the definition and use of the LUID.
        /// </summary>
        public long Attributes;
    }

    public class SE
    {
        public const long PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001L;
        public const long PRIVILEGE_ENABLED = 0x00000002L;
        public const long PRIVILEGE_REMOVED = 0X00000004L;
        public const long PRIVILEGE_USED_FOR_ACCESS = 0x80000000L;
        public const string CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
        public const string ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
        public const string LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
        public const string INCREAQUOTA_NAME = "SeIncreaseQuotaPrivilege";
        public const string UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
        public const string MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
        public const string TCB_NAME = "SeTcbPrivilege";
        public const string SECURITY_NAME = "SeSecurityPrivilege";
        public const string TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
        public const string LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
        public const string SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
        public const string SYSTEMTIME_NAME = "SeSystemtimePrivilege";
        public const string PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
        public const string INC_BAPRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
        public const string CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
        public const string CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
        public const string BACKUP_NAME = "SeBackupPrivilege";
        public const string RESTORE_NAME = "SeRestorePrivilege";
        public const string SHUTDOWN_NAME = "SeShutdownPrivilege";
        public const string DEBUG_NAME = "SeDebugPrivilege";
        public const string AUDIT_NAME = "SeAuditPrivilege";
        public const string SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
        public const string CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
        public const string REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
        public const string UNDOCK_NAME = "SeUndockPrivilege";
        public const string SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
        public const string ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
        public const string MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
        public const string IMPERSONATE_NAME = "SeImpersonatePrivilege";
        public const string CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";
        public const string TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";
        public const string RELABEL_NAME = "SeRelabelPrivilege";
        public const string INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";
        public const string TIME_ZONE_NAME = "SeTimeZonePrivilege";
        public const string CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
    }

    public enum TOKEN
    {
        ASSIGN_PRIMARY = 0x0001,
        DUPLICATE = 0x0002,
        IMPERSONATE = 0x0004,
        QUERY = 0x0008,
        QUERY_SOURCE = 0x0010,
        ADJUST_PRIVILEGES = 0x0020,
        ADJUST_GROUPS = 0x0040,
        ADJUST_DEFAULT = 0x0080,
        ADJUST_SESSIONID = 0x0100
    }

    /// <summary>
    /// The TOKEN_PRIVILEGES structure contains information about a set of privileges for an access token.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TOKEN_PRIVILEGES
    {
        /// <summary>
        /// This must be set to the number of entries in the Privileges array.
        /// </summary>
        public int PrivilegeCount;
        /// <summary>
        /// Specifies an array of LUID_AND_ATTRIBUTES structures. Each structure contains the LUID and attributes of a privilege. To get the name of the privilege associated with a LUID, call the LookupPrivilegeName function, passing the address of the LUID as the value of the lpLuid parameter.
        /// <para>Important  The constant ANYSIZE_ARRAY is defined as 1 in the public header Winnt.h. To create this array with more than one element, you must allocate sufficient memory for the structure to take into account additional elements.</para>
        /// <para>The attributes of a privilege can be a combination of the following values. </para>
        /// <para>Value	: Meaning</para>
        /// <para>SE_PRIVILEGE_ENABLED : The privilege is enabled.</para>
        /// <para>SE_PRIVILEGE_ENABLED_BY_DEFAULT : The privilege is enabled by default.</para>
        /// <para>SE_PRIVILEGE_REMOVED : Used to remove a privilege.For details, see AdjustTokenPrivileges.</para>
        /// <para>SE_PRIVILEGE_USED_FOR_ACCESS : The privilege was used to gain access to an object or service.This flag is used to identify the relevant privileges in a set passed by a client application that may contain unnecessary privileges.</para>
        /// </summary>
        public LUID_AND_ATTRIBUTES Privileges;
    }
}
