import ctypes
import ctypes.wintypes
from typing import Optional

class MemoryManager:
    def __init__(self, process_name: str = "Subnautica2.exe"):
        self.process_name = process_name
        self.process_handle: Optional[int] = None
        self._open_process()

    def _open_process(self) -> None:
        kernel32 = ctypes.windll.kernel32
        PROCESS_ALL_ACCESS = 0x1F0FFF
        pid = self._find_process_id()
        if pid:
            self.process_handle = kernel32.OpenProcess(PROCESS_ALL_ACCESS, False, pid)

    def _find_process_id(self) -> Optional[int]:
        import psutil
        for proc in psutil.process_iter(['pid', 'name']):
            if proc.info['name'] == self.process_name:
                return proc.info['pid']
        return None

    def read_float(self, address: int) -> float:
        if not self.process_handle:
            return 0.0
        buffer = ctypes.c_float()
        bytes_read = ctypes.c_size_t()
        ctypes.windll.kernel32.ReadProcessMemory(
            self.process_handle, address, ctypes.byref(buffer),
            ctypes.sizeof(buffer), ctypes.byref(bytes_read)
        )
        return buffer.value

    def write_float(self, address: int, value: float) -> bool:
        if not self.process_handle:
            return False
        buffer = ctypes.c_float(value)
        bytes_written = ctypes.c_size_t()
        result = ctypes.windll.kernel32.WriteProcessMemory(
            self.process_handle, address, ctypes.byref(buffer),
            ctypes.sizeof(buffer), ctypes.byref(bytes_written)
        )
        return bool(result)

    def close(self) -> None:
        if self.process_handle:
            ctypes.windll.kernel32.CloseHandle(self.process_handle)