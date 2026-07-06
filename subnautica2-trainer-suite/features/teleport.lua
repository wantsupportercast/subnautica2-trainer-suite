local Teleport = {}

local waypoints = {}

function Teleport:saveWaypoint(name)
    waypoints[name] = { x = math.random(-500, 500), y = math.random(-200, 0), z = math.random(-500, 500) }
    print("[Teleport] Waypoint '" .. name .. "' saved at (" .. waypoints[name].x .. ", " .. waypoints[name].y .. ", " .. waypoints[name].z .. ").")
end

function Teleport:gotoWaypoint(name)
    if waypoints[name] then
        local wp = waypoints[name]
        print("[Teleport] Teleporting to '" .. name .. "' at (" .. wp.x .. ", " .. wp.y .. ", " .. wp.z .. ").")
    else
        print("[Teleport] Waypoint '" .. name .. "' not found.")
    end
end

function Teleport:listWaypoints()
    print("[Teleport] Saved waypoints:")
    for k, v in pairs(waypoints) do
        print("  " .. k .. " -> (" .. v.x .. ", " .. v.y .. ", " .. v.z .. ")")
    end
end

return Teleport