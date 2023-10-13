using static Deorium.Offsets;
using static Deorium.Inject;
using static Deorium.Variables;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Deorium
{
    class Functions
    {

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys ArrowKeys);
        public static void FuncGlow()
        {
            Thread.Sleep(1);

            int localPlayer = mem.Read<int>(clientdll + dwLocalPlayer);
            int ourteam = mem.Read<int>(localPlayer + m_iTeamNum);

            for (byte i = 0; i < 64; i++)
            {
                int entityList = mem.Read<int>(clientdll + dwEntityList + i * 0x10);
                int otherTeam = mem.Read<int>(entityList + m_iTeamNum);
                int enemyHP = mem.Read<int>(entityList + m_iHealth);

                if (glowStatus)
                {
                    if (entityList != 0)
                    {
                        if (otherTeam != 0 && otherTeam != ourteam)
                        {
                            int glowID = mem.Read<int>(entityList + m_iGlowIndex);

                            switch (clrGlow)
                            {
                                case "red":
                                    DrawPlayer(glowID, 255, 0, 0);
                                    break;
                                case "green":
                                    DrawPlayer(glowID, 0, 255, 0);
                                    break;
                                case "blue":
                                    DrawPlayer(glowID, 0, 0, 255);
                                    break;
                                case "yellow":
                                    DrawPlayer(glowID, 255, 255, 0);
                                    break;
                                case "pink":
                                    DrawPlayer(glowID, 255, 0, 255);
                                    break;
                                default:
                                    DrawPlayer(glowID, 255, 0, 0);
                                    break;
                            }
                        }
                    }
                }
            }
        }
        public static void FuncRadar()
        {
            Thread.Sleep(1);
            if (radarStatus)
            {
                for (int i = 0; i < 64; i++)
                {
                    int entityList = mem.Read<int>(clientdll + dwEntityList + i * 0x10);
                    mem.Write<int>(entityList + m_bSpotted, 1);
                }
            }
        }
        public static void FuncBhop()
        {
            Thread.Sleep(1);
            if (bhopStatus)
            {
                int localPlayer = mem.Read<int>(clientdll + dwLocalPlayer);
                int flag = mem.Read<int>(localPlayer + m_fFlags);

                if (GetAsyncKeyState(Keys.Space) < 0)
                {
                    if (flag == 257 || flag == 263)
                    {
                        mem.Write(clientdll + dwForceJump, 5);
                        Thread.Sleep(1);
                        mem.Write(clientdll + dwForceJump, 4);
                    }
                }
            }
        }
        public static void FuncAntiflash()
        {
            Thread.Sleep(1);
            if (antiflashStatus)
            {
                int localPlayer = mem.Read<int>(clientdll + dwLocalPlayer);
                mem.Write(localPlayer + m_flFlashDuration, 0);
            }
        }
        public static void FuncChams()
        {
            Thread.Sleep(1);
            for (int i = 0; i < 32; i++)
            {
                if (chamsStatus)
                {
                    int entityList = mem.Read<int>(clientdll + dwEntityList + i * 0x10);
                    int otherTeam = mem.Read<int>(entityList + m_iTeamNum);
                    int localPlayer = mem.Read<int>(clientdll + dwLocalPlayer);
                    int ourteam = mem.Read<int>(localPlayer + m_iTeamNum);

                    if (entityList != 0)
                    {
                        if (otherTeam != 0 && otherTeam != ourteam)
                        {
                            switch (clrChams)
                            {
                                case "red":
                                    mem.Write<int>(entityList + m_clrRender, 255);
                                    mem.Write<int>(entityList + m_clrRender + 1, 0);
                                    mem.Write<int>(entityList + m_clrRender + 2, 0);
                                    mem.Write<int>(entityList + m_clrRender + 3, 255);
                                    break;
                                case "green":
                                    mem.Write<int>(entityList + m_clrRender, 0);
                                    mem.Write<int>(entityList + m_clrRender + 1, 255);
                                    mem.Write<int>(entityList + m_clrRender + 2, 0);
                                    mem.Write<int>(entityList + m_clrRender + 3, 255);
                                    break;
                                case "blue":
                                    mem.Write<int>(entityList + m_clrRender, 0);
                                    mem.Write<int>(entityList + m_clrRender + 1, 0);
                                    mem.Write<int>(entityList + m_clrRender + 2, 255);
                                    mem.Write<int>(entityList + m_clrRender + 3, 255);
                                    break;
                                case "yellow":
                                    mem.Write<int>(entityList + m_clrRender, 255);
                                    mem.Write<int>(entityList + m_clrRender + 1, 255);
                                    mem.Write<int>(entityList + m_clrRender + 2, 0);
                                    mem.Write<int>(entityList + m_clrRender + 3, 255);
                                    break;
                                case "pink":
                                    mem.Write<int>(entityList + m_clrRender, 255);
                                    mem.Write<int>(entityList + m_clrRender + 1, 255);
                                    mem.Write<int>(entityList + m_clrRender + 2, 0);
                                    mem.Write<int>(entityList + m_clrRender + 3, 255);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    int entityList = mem.Read<int>(clientdll + dwEntityList + i * 0x10);
                    int otherTeam = mem.Read<int>(entityList + m_iTeamNum);
                    int localPlayer = mem.Read<int>(clientdll + dwLocalPlayer);
                    int ourteam = mem.Read<int>(localPlayer + m_iTeamNum);

                    if (entityList != 0)
                    {
                        if (otherTeam != 0 && otherTeam != ourteam)
                        {
                            mem.Write<int>(entityList + m_clrRender, 255);
                            mem.Write<int>(entityList + m_clrRender + 1, 255);
                            mem.Write<int>(entityList + m_clrRender + 2, 255);
                            mem.Write<int>(entityList + m_clrRender + 3, 255);
                        }
                    }
                }
            }
        }
        public static void DrawPlayer(int glowID, int red, int green, int blue)
        {
            int glowObject = mem.Read<int>(clientdll + dwGlowObjectManager);

            mem.Write(glowObject + (glowID * 0x38) + 0x8, red / 100f);
            mem.Write(glowObject + (glowID * 0x38) + 0xC, green / 100f);
            mem.Write(glowObject + (glowID * 0x38) + 0x10, blue / 100f);
            mem.Write(glowObject + (glowID * 0x38) + 0x14, 255 / 100f);
            mem.Write(glowObject + (glowID * 0x38) + 0x28, true);
            mem.Write(glowObject + (glowID * 0x38) + 0x29, false);
        }
    }
}
