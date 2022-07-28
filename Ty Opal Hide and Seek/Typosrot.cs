using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Ty_Opal_Hide_and_Seek
{
    public class Typosrot
    {
        const int PROCESS_WM_READ = 0x0010;
        const int TYPOSX = 0x005C0B78;
        const int TYPOSY = 0x005C0B7C;
        const int TYPOSZ = 0x005C0B80;
        const int BPPOSX = 0x005A4268;
        const int BPPOSY = 0x005A426C;
        const int BPPOSZ = 0x005A4270;
        const int LEVELID = 0x005D0594;
        public float floatTyPosX;
        public float floatTyPosY;
        public float floatTyPosZ;
        public float floatBpPosX;
        public float floatBpPosY;
        public float floatBpPosZ;
        public int currentLevelID;
        public Process typrocess;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public Typosrot()
        {
            
        }

        public void GetTyPos()
        {
            Process tyexe = FindTyexe();
            if (tyexe != null)
            {
                IntPtr tyexeHandle = OpenProcess(PROCESS_WM_READ, false, tyexe.Id);

                int bytesRead = 0;
                byte[] tyPosX = new byte[4];
                byte[] tyPosY = new byte[4];
                byte[] tyPosZ = new byte[4];
                byte[] bpPosX = new byte[4];
                byte[] bpPosY = new byte[4];
                byte[] bpPosZ = new byte[4];
                byte[] currentLevel = new byte[4];
                ReadProcessMemory((int)tyexeHandle, TYPOSX, tyPosX, 4, ref bytesRead);
                ReadProcessMemory((int)tyexeHandle, TYPOSY, tyPosY, 4, ref bytesRead);
                ReadProcessMemory((int)tyexeHandle, TYPOSZ, tyPosZ, 4, ref bytesRead);
                ReadProcessMemory((int)tyexeHandle, BPPOSX, bpPosX, 4, ref bytesRead);
                ReadProcessMemory((int)tyexeHandle, BPPOSY, bpPosY, 4, ref bytesRead);
                ReadProcessMemory((int)tyexeHandle, BPPOSZ, bpPosZ, 4, ref bytesRead);
                ReadProcessMemory((int)tyexeHandle, LEVELID, currentLevel, 4, ref bytesRead);
                floatTyPosX = BitConverter.ToSingle(tyPosX, 0);
                floatTyPosY = BitConverter.ToSingle(tyPosY, 0);
                floatTyPosZ = BitConverter.ToSingle(tyPosZ, 0);
                floatBpPosX = BitConverter.ToSingle(bpPosX, 0);
                floatBpPosY = BitConverter.ToSingle(bpPosY, 0);
                floatBpPosZ = BitConverter.ToSingle(bpPosZ, 0);
                currentLevelID = BitConverter.ToInt32(currentLevel, 0);
            }
        }

        public Process FindTyexe()
        {
            foreach (Process p in Process.GetProcesses("."))
            {
                if (p.MainWindowTitle == "TY the Tasmanian Tiger")
                {
                    typrocess = p;
                    return p;
                }
            }
            typrocess = null;
            return null;
        }


    }
}
