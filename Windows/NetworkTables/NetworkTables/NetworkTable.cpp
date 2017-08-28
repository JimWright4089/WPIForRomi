// NetworkTableTemp.cpp : Defines the exported functions for the DLL application.
//
#include <objbase.h>
#include <tchar.h>
#include "NetworkTable.h"
#include "ntcore.h"


NETWORKTABLE_API void DeleteEntry(char* name)
{
    nt::DeleteEntry(name);
}

NETWORKTABLE_API void DeleteAllEntries()
{
    nt::DeleteAllEntries();
}

NETWORKTABLE_API void SetNetworkIdentity(char* name)
{
    nt::SetNetworkIdentity(name);
}

NETWORKTABLE_API void StartServer(char* persist_filename, const char* listen_address, unsigned int port)
{
    nt::StartServer(persist_filename, listen_address, port);
}

NETWORKTABLE_API void StopServer()
{
    nt::StopServer();
}

NETWORKTABLE_API void StartClient()
{
    nt::StartClient();
}

NETWORKTABLE_API void StartClient(const char* server_name, unsigned int port)
{
    nt::StartClient(server_name, port);
}

NETWORKTABLE_API void StopClient()
{
    nt::StopClient();
}

NETWORKTABLE_API void SetServer(const char* server_name, unsigned int port)
{
    nt::SetServer(server_name, port);
}

NETWORKTABLE_API void StartDSClient(unsigned int port)
{
    nt::StartDSClient(port);
}

NETWORKTABLE_API void StopDSClient()
{
    nt::StopDSClient();
}

NETWORKTABLE_API void StopRpcServer()
{
    nt::StopRpcServer();
}

NETWORKTABLE_API void StopNotifier()
{
    nt::StopNotifier();
}

NETWORKTABLE_API void SetUpdateRate(double interval)
{
    nt::SetUpdateRate(interval);
}

NETWORKTABLE_API char* GetEntryValueString(char* name)
{
    auto returnValue = nt::GetEntryValue(name);

    if (returnValue && returnValue->IsString())
    {
        ULONG ulSize = strlen(returnValue->GetString().data()) + sizeof(char);
        char* pszReturn = NULL;

        pszReturn = (char*)::CoTaskMemAlloc(ulSize);
        // Copy the contents of szSampleString
        // to the memory pointed to by pszReturn.
        strcpy(pszReturn, returnValue->GetString().data());
        // Return pszReturn.
        return pszReturn;
    }

    char szSampleString[] = "";
    ULONG ulSize = strlen(szSampleString) + sizeof(char);
    char* pszReturn = NULL;

    pszReturn = (char*)::CoTaskMemAlloc(ulSize);
    // Copy the contents of szSampleString
    // to the memory pointed to by pszReturn.
    strcpy(pszReturn, szSampleString);
    // Return pszReturn.
    return pszReturn;
}

NETWORKTABLE_API double GetEntryValueDouble(char* name)
{
    auto returnValue = nt::GetEntryValue(name);

    if (returnValue && returnValue->IsDouble())
    {
        return returnValue->GetDouble();
    }

    if (returnValue && returnValue->IsBoolean())
    {
        if (returnValue->GetBoolean())
        {
            return 1.0;
        }
        else
        {
            return 0.0;
        }
    }

    return 0.0;
}

NETWORKTABLE_API BOOL GetEntryValueBool(char* name)
{
    auto returnValue = nt::GetEntryValue(name);

    if (returnValue && returnValue->IsBoolean())
    {
        return (returnValue->GetBoolean()?TRUE:FALSE);
    }

    return FALSE;
}

NETWORKTABLE_API bool SetDefaultEntryValueString(char* name, char* value)
{
    return nt::SetDefaultEntryValue(name, nt::Value::MakeString(value));
}

NETWORKTABLE_API bool SetDefaultEntryValueDouble(char* name, double value)
{
    return nt::SetDefaultEntryValue(name, nt::Value::MakeDouble(value));
}

NETWORKTABLE_API bool SetDefaultEntryValueBool(char* name, bool value)
{
    return nt::SetDefaultEntryValue(name, nt::Value::MakeBoolean(value));
}

NETWORKTABLE_API void SetEntryFlags(char* name, unsigned int flags)
{
    nt::SetEntryFlags(name, flags);
}

NETWORKTABLE_API unsigned int GetEntryFlags(char* name)
{
    return nt::GetEntryFlags(name);
}

NETWORKTABLE_API void Flush()
{
    nt::Flush();
}

NETWORKTABLE_API bool SetEntryValueString(char* name, char* value)
{
    return nt::SetEntryValue(name, nt::Value::MakeString(value));
}

NETWORKTABLE_API bool SetEntryValueDouble(char* name, double value)
{
    return nt::SetEntryValue(name, nt::Value::MakeDouble(value));
}

NETWORKTABLE_API bool SetEntryValueBool(char* name, bool value)
{
    return nt::SetEntryValue(name, nt::Value::MakeBoolean(value));
}

NETWORKTABLE_API void SetEntryTypeValueString(char* name, char* value)
{
    return nt::SetEntryTypeValue(name, nt::Value::MakeString(value));
}

NETWORKTABLE_API void SetEntryTypeValueDouble(char* name, double value)
{
    return nt::SetEntryTypeValue(name, nt::Value::MakeDouble(value));
}

NETWORKTABLE_API void SetEntryTypeValueBool(char* name, bool value)
{
    return nt::SetEntryTypeValue(name, nt::Value::MakeBoolean(value));
}


