using System;
using System.Runtime.InteropServices;
using System.IO;

namespace ConvertTacho
{
 /// 
 /// Summary description for WPlaySound.
 /// 
 public class WPlaySound
 {
  [DllImport("winmm.dll", EntryPoint="PlaySound",CharSet=CharSet.Auto)]
  private static extern int PlaySound(String pszSound, int hmod, int falgs);

  public WPlaySound()
  {
   //
   // TODO: Add constructor logic here
   //
  }

  public enum SND
  {
   SND_SYNC        = 0x0000  ,/* play synchronously (default) */
   SND_ASYNC        = 0x0001 , /* play asynchronously */
   SND_NODEFAULT        = 0x0002 , /* silence (!default) if sound not found 
*/
   SND_MEMORY        = 0x0004 , /* pszSound points to a memory file */
   SND_LOOP        = 0x0008 , /* loop the sound until next sndPlaySound */
   SND_NOSTOP        = 0x0010 , /* don't stop any currently playing sound 
*/
   SND_NOWAIT        = 0x00002000, /* don't wait if the driver is busy */
   SND_ALIAS        = 0x00010000 ,/* name is a registry alias */
   SND_ALIAS_ID        = 0x00110000, /* alias is a pre d ID */
   SND_FILENAME        = 0x00020000, /* name is file name */
   SND_RESOURCE        = 0x00040004, /* name is resource name or atom 
*/
   SND_PURGE        = 0x0040,  /* purge non-static events for task */
   SND_APPLICATION        = 0x0080  /* look for application specific 
association */
  }

  /// 
  /// Wave 파일 재생
  /// 
  /// 파일 경로
  public static void PlaySound(String pszSound)
  {
   if(File.Exists(pszSound))
   {
       PlaySound(pszSound, 0, (int)(SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT | SND.SND_NOSTOP));
   }
   else
   {
    PlaySound(null, 0,(int) (SND.SND_ASYNC | SND.SND_FILENAME | SND.SND_NOWAIT ));
   }

  }
  /// 
  /// 시스템 사운드 이벤트 HKEY_CURRENT_USER\AppEvents\Schemes  \Apps\.Default
       /// 
       /// 이벤트 이름
  public static void PlaySoundEvent(String pszSound)
  {   
   PlaySound(pszSound,0,(int) (SND.SND_ASYNC | SND.SND_ALIAS | SND.SND_NOWAIT));
   
  }
 
 }
}


/* 

먼저 위의 소스를 별도로 저장하여 프로젝트에 포함시키세요. cs파일 형태로요.

위 클래스에는 dll임포트와 PlaySound메소드를 포함하여 메소드를 이용하면 바로

wav파일을 재생시킬 수 있습니다.

참 namespace는 맞춰주셔야 번거롭지 않겠죠?

별도로 참조추가를 해서 dll을 포함시킬 필요는 없습니다.

 

사용예

 

   string dir = Directory.GetCurrentDirectory();
   dir += "\\ding.wav";

   WPlaySound.PlaySound(dir);

*/