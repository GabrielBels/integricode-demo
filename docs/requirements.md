# Requirements

## [REQ-001] Cap a Number Search at 100 Numbers

**Description**: Users paste a list of order numbers into the search box. A long list times out the order lookup, so a search accepts at most 100 numbers and rejects a longer list with a clear message instead of timing out.

**Priority**: High

**Acceptance Criteria**:
- [ ] A search accepts at most 100 numbers.
- [ ] A search with more than 100 numbers is rejected with the message "At most 100 numbers per search."
- [ ] A number repeated in the input counts once toward the limit.
- [ ] Tests cover the boundary: 100 numbers pass, 101 are rejected.

**Context/Notes**: The search box input is parsed by `NumberSearch.Parse` in `src/Search/NumberSearch.cs`.
