local suite = {}
suite.version = "1.0.0"
suite.author = "Trainer Dev Team"
suite.name = "Subnautica 2 Trainer Suite"

function suite:start()
    print("[Trainer] " .. self.name .. " v" .. self.version .. " loaded.")
    print("[Trainer] Use /trainer help for commands.")
end

function suite:help()
    print("Commands: god, oxygen, speed, teleport, help")
end

return suite