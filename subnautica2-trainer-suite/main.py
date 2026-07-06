import sys
import time
from src import TrainerCore

def show_menu():
    print("\n=== Subnautica 2 Trainer Suite ===")
    print("1. Set Oxygen to 100")
    print("2. Set Health to 100")
    print("3. Enable Infinite Oxygen (loop)")
    print("4. Exit")

def main():
    trainer = TrainerCore()
    try:
        while True:
            show_menu()
            choice = input("Select option: ").strip()
            if choice == "1":
                trainer.set_oxygen(100.0)
            elif choice == "2":
                trainer.set_health(100.0)
            elif choice == "3":
                print("Infinite oxygen running (5 sec)...")
                trainer.infinite_oxygen_loop(interval=0.5)
                time.sleep(5)
                trainer.stop()
            elif choice == "4":
                print("Exiting...")
                break
            else:
                print("Invalid option.")
    except KeyboardInterrupt:
        pass
    finally:
        trainer.stop()
        sys.exit(0)

if __name__ == "__main__":
    main()