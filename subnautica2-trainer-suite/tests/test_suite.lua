local suite = require("init")
local player = require("features.player")
local teleport = require("features.teleport")
local commands = require("commands")

local tests_passed = 0
local tests_failed = 0

function assert_equal(expected, actual, msg)
    if expected == actual then
        tests_passed = tests_passed + 1
    else
        tests_failed = tests_failed + 1
        print("[TEST FAIL] " .. msg .. " - expected: " .. tostring(expected) .. ", got: " .. tostring(actual))
    end
end

-- Test suite init
suite:start()
assert_equal("1.0.0", suite.version, "Version should be 1.0.0")

-- Test player features
player:setGodMode(true)
player:setInfiniteOxygen(false)
player:setSpeedMultiplier(2.5)

-- Test teleport
teleport:saveWaypoint("base")
teleport:saveWaypoint("cave")
teleport:gotoWaypoint("base")
teleport:listWaypoints()

-- Test commands
commands:execute("help")
commands:execute("god on")
commands:execute("oxygen off")
commands:execute("speed 3.0")
commands:execute("teleport save base")
commands:execute("teleport goto base")
commands:execute("teleport list")
commands:execute("unknown")

-- Summary
print("\n=== Test Summary ===")
print("Passed: " .. tests_passed)
print("Failed: " .. tests_failed)
if tests_failed == 0 then
    print("All tests passed!")
else
    print("Some tests failed.")
end