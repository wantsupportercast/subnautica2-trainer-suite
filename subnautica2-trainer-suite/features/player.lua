local Player = {}

function Player:setGodMode(enabled)
    if enabled then
        print("[Player] God mode ON - you are invincible.")
    else
        print("[Player] God mode OFF.")
    end
end

function Player:setInfiniteOxygen(enabled)
    if enabled then
        print("[Player] Infinite oxygen enabled.")
    else
        print("[Player] Oxygen depletion restored.")
    end
end

function Player:setSpeedMultiplier(mult)
    local clamped = math.max(0.5, math.min(5.0, mult))
    print("[Player] Speed multiplier set to " .. string.format("%.1f", clamped) .. "x.")
end

return Player