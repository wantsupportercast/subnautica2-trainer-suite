import time
from .memory import MemoryManager
from colorama import init, Fore

init(autoreset=True)

class TrainerCore:
    def __init__(self):
        self.mem = MemoryManager()
        self.oxygen_address = 0x12345678  # placeholder
        self.health_address = 0x87654321  # placeholder
        self.active = False

    def set_oxygen(self, value: float) -> None:
        if self.mem.write_float(self.oxygen_address, value):
            print(f"{Fore.CYAN}[O2] Set to {value}")

    def set_health(self, value: float) -> None:
        if self.mem.write_float(self.health_address, value):
            print(f"{Fore.GREEN}[HP] Set to {value}")

    def infinite_oxygen_loop(self, interval: float = 1.0) -> None:
        self.active = True
        while self.active:
            self.set_oxygen(100.0)
            time.sleep(interval)

    def stop(self) -> None:
        self.active = False
        self.mem.close()
        print(f"{Fore.YELLOW}Trainer stopped.")