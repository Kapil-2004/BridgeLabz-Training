using System;

namespace ParcelTracker
{
interface IParcelTracker
{
    void AddParcel();
    void AddCheckpoint();
    void TrackParcel();
    void MarkParcelLost();
}
}