import unittest
from unittest.mock import patch, MagicMock
from src.trainer import TrainerCore

class TestTrainerCore(unittest.TestCase):
    @patch('src.trainer.MemoryManager')
    def test_set_oxygen(self, mock_mem):
        mock_instance = mock_mem.return_value
        mock_instance.write_float.return_value = True
        trainer = TrainerCore()
        trainer.set_oxygen(100.0)
        mock_instance.write_float.assert_called_once_with(0x12345678, 100.0)

    @patch('src.trainer.MemoryManager')
    def test_set_health(self, mock_mem):
        mock_instance = mock_mem.return_value
        mock_instance.write_float.return_value = True
        trainer = TrainerCore()
        trainer.set_health(50.0)
        mock_instance.write_float.assert_called_once_with(0x87654321, 50.0)

    @patch('src.trainer.MemoryManager')
    def test_stop_closes_memory(self, mock_mem):
        mock_instance = mock_mem.return_value
        trainer = TrainerCore()
        trainer.stop()
        mock_instance.close.assert_called_once()

if __name__ == "__main__":
    unittest.main()