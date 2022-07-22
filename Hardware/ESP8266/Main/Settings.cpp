#ifndef _SETTINGS_H    // Put these two lines at the top of your file.
#define _SETTINGS_H
#include "Settings.h"
#include <EEPROM.h>
#endif



 
// load whats in EEPROM in to the local CONFIGURATION if it is a valid setting
int loadConfig() {
  // is it correct?
  if (EEPROM.read(CONFIG_START + 0) == CONFIG_VERSION[0] &&
      EEPROM.read(CONFIG_START + 1) == CONFIG_VERSION[1] &&
      EEPROM.read(CONFIG_START + 2) == CONFIG_VERSION[2] &&
      EEPROM.read(CONFIG_START + 3) == CONFIG_VERSION[3] &&
      EEPROM.read(CONFIG_START + 4) == CONFIG_VERSION[4]){
 
  // load (overwrite) the local configuration struct
    for (unsigned int i=0; i<sizeof(CONFIGURATION); i++){
      *((char*)&CONFIGURATION + i) = EEPROM.read(CONFIG_START + i);
    }
    return 1; // return 1 if config loaded 
  }
  return 0; // return 0 if config NOT loaded
}
 
// save the CONFIGURATION in to EEPROM
void saveConfig() {
  for (unsigned int i=0; i<sizeof(CONFIGURATION); i++)
    EEPROM.write(CONFIG_START + i, *((char*)&CONFIGURATION + i));    
}
