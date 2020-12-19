import { createStructuredSelector } from 'reselect';

import { IStore } from '../../reducers';
import { isLoading } from '../../selectors/loading';
import { ILoadingOwmProps, ILoadingSelectedProps } from './_Loading';

export default createStructuredSelector<IStore, ILoadingOwmProps, ILoadingSelectedProps>({
  isLoading,
});
