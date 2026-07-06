local suite = require("init")
local player = require("features.player")
local teleport = require("features.teleport")

local Commands = {}

function Commands:execute(input)
    local parts = {}
    for word in input:gmatch("%S+") do
        table.insert(parts, word)
    end

    if #parts == 0 then
        print("[Commands] Usage: /trainer <command> [args]")
        return
    end

    local cmd = parts[1]
    local arg = parts[2]

    if cmd == "help" then
        suite:help()
    elseif cmd == "god" then
        player:setGodMode(arg == "on" or arg == nil)
    elseif cmd == "oxygen" then
        player:setInfiniteOxygen(arg == "on" or arg == nil)
    elseif cmd == "speed" then
        local mult = tonumber(arg) or 1.0
        player:setSpeedMultiplier(mult)
    elseif cmd == "teleport" and arg == "save" then
        teleport:saveWaypoint(parts[3] or "default")
    elseif cmd == "teleport" and arg == "goto" then
        teleport:gotoWaypoint(parts[3] or "default")
    elseif cmd == "teleport" and arg == "list" then
        teleport:listWaypoints()
    else
        print("[Commands] Unknown command: " .. cmd)
    end
end

return Commands