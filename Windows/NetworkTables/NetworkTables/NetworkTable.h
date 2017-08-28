#ifdef NETWORKTABLE_EXPORTS
#define NETWORKTABLE_API __declspec(dllexport)
#else
#define NETWORKTABLE_API __declspec(dllimport)
#endif

extern "C"
{
    NETWORKTABLE_API void DeleteEntry(char* name);
    NETWORKTABLE_API void DeleteAllEntries();

    NETWORKTABLE_API void SetNetworkIdentity(char* name);
    NETWORKTABLE_API void StartServer(char* persist_filename, const char* listen_address, unsigned int port);

    NETWORKTABLE_API void StopServer();

//    NETWORKTABLE_API void StartClient();
    NETWORKTABLE_API void StartClient(const char* server_name, unsigned int port);

    NETWORKTABLE_API void StopClient();

    NETWORKTABLE_API void SetServer(const char* server_name, unsigned int port);

    NETWORKTABLE_API void StartDSClient(unsigned int port);
    NETWORKTABLE_API void StopDSClient();
    NETWORKTABLE_API void StopRpcServer();
    NETWORKTABLE_API void StopNotifier();
    NETWORKTABLE_API void SetUpdateRate(double interval);

    NETWORKTABLE_API char* GetEntryValueString(char* name);
    NETWORKTABLE_API double GetEntryValueDouble(char* name);
    NETWORKTABLE_API BOOL GetEntryValueBool(char* name);

    NETWORKTABLE_API bool SetDefaultEntryValueString(char* name, char* value);
    NETWORKTABLE_API bool SetDefaultEntryValueDouble(char* name, double value);
    NETWORKTABLE_API bool SetDefaultEntryValueBool(char* name, bool value);

    NETWORKTABLE_API void SetEntryFlags(char* name, unsigned int flags);
    NETWORKTABLE_API unsigned int GetEntryFlags(char* name);
    NETWORKTABLE_API void Flush();

    NETWORKTABLE_API bool SetEntryValueString(char* name, char* value);
    NETWORKTABLE_API bool SetEntryValueDouble(char* name, double value);
    NETWORKTABLE_API bool SetEntryValueBool(char* name, bool value);

    NETWORKTABLE_API void SetEntryTypeValueString(char* name, char* value);
    NETWORKTABLE_API void SetEntryTypeValueDouble(char* name, double value);
    NETWORKTABLE_API void SetEntryTypeValueBool(char* name, bool value);
}

